using NHibernate;
using NHibernateLab.Entities;
using NHibernateLab.NHibernate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHibernateLab.Services.Implementations {
    public class TeacherService : EntityService<Teacher> {
        public override async Task<IList<Teacher>> GetAllAsync() {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "FROM Teacher t " +
             "LEFT JOIN FETCH t.Department dep " +
             "LEFT JOIN FETCH t.Degree deg " +
             "LEFT JOIN FETCH t.Rank r ";

                IQuery query = session.CreateQuery(hql);
                return await query.ListAsync<Teacher>();
            }
        }

        public async override Task<IList<Teacher>> SearchAsync(string text) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "FROM Teacher t " +
                    "LEFT JOIN FETCH t.Department dep " +
                    "LEFT JOIN FETCH t.Degree deg " +
                    "LEFT JOIN FETCH t.Rank r " +
                    "WHERE " +
                    "LOWER(t.FirstName) LIKE LOWER(:searchText) OR " +
                    "LOWER(t.LastName) LIKE LOWER(:searchText) OR " +
                    "LOWER(t.Patronymic) LIKE LOWER(:searchText) OR " +
                    "LOWER(dep.Name) LIKE LOWER(:searchText) OR " +
                    "LOWER(deg.Name) LIKE LOWER(:searchText) OR " +
                    "LOWER(r.Name) LIKE LOWER(:searchText)";

                IQuery query = session.CreateQuery(hql);
                query.SetString("searchText", $"%{text}%");

                return await query.ListAsync<Teacher>();
            }
        }

        public async override Task UpdateAsync(Teacher entity) {
             using (ISession session = NHibernateHelper.OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    Teacher teacherToUpdate = session.Get<Teacher>(entity.Id);

                    teacherToUpdate.FirstName = entity.FirstName;
                    teacherToUpdate.LastName = entity.LastName;
                    teacherToUpdate.Patronymic = entity.Patronymic;
                    teacherToUpdate.Email = entity.Email;
                    teacherToUpdate.Phone = entity.Phone;

                    Department newDepartment = session.Get<Department>(entity.Department.Id);
                    Degree newDegree = session.Get<Degree>(entity.Degree.Id);
                    Rank newRank = session.Get<Rank>(entity.Rank.Id);
                    teacherToUpdate.Department = newDepartment;
                    teacherToUpdate.Degree = newDegree;
                    teacherToUpdate.Rank = newRank;

                    await session.UpdateAsync(teacherToUpdate);

                    await transaction.CommitAsync();
                }
            }
        }
    }
}
