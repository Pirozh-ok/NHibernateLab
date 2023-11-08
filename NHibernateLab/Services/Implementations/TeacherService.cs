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
                    "LOWER(s.FirstName) LIKE LOWER(:searchText) OR " +
                    "LOWER(s.LastName) LIKE LOWER(:searchText) OR " +
                    "LOWER(s.Patronymic) LIKE LOWER(:searchText) OR " +
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
                string hql = "UPDATE Teacher t " +
             "SET t.FirstName = :newFirstName, " +
             "t.LastName = :newLastName, " +
             "t.Patronymic = :newPatronymic, " +
             "t.DepartmentId = :newDepartment " +
             "t.DegreeId = :newDegree " +
             "t.RankId = :newRank " +
             "WHERE t.Id = :id";

                IQuery query = session.CreateQuery(hql);
                query.SetString("newFirstName", entity.FirstName);
                query.SetString("newLastName", entity.LastName);
                query.SetString("newPatronymic", entity.Patronymic);
                query.SetInt32("id", entity.Id);
                query.SetInt32("DepartmentId", entity.Department.Id);
                query.SetInt32("DegreeId", entity.Degree.Id);
                query.SetInt32("RankId", entity.Rank.Id);

                int updatedCount = await query.ExecuteUpdateAsync();
            }
        }
    }
}
