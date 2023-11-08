using NHibernate;
using NHibernateLab.Entities;
using NHibernateLab.NHibernate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHibernateLab.Services.Implementations {
    public class MarkService : EntityService<Mark> {
        public override async Task<IList<Mark>> GetAllAsync() {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "FROM Mark m " +
             "LEFT JOIN FETCH m.Student s " +
             "ORDER BY m.Id";

                IQuery query = session.CreateQuery(hql);
                return await query.ListAsync<Mark>();
            }
        }

        public async override Task<IList<Mark>> SearchAsync(string text) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "FROM Mark m " +
                    "LEFT JOIN FETCH m.Student s " +
                    "WHERE " +
                    "CAST(m.DefendMark AS string) LIKE :searchText OR " +
                    "CAST(m.ExamMark AS string) LIKE :searchText OR " +
                    "LOWER(s.FirstName) LIKE LOWER(:searchText) OR " +
                    "LOWER(s.LastName) LIKE LOWER(:searchText) OR " +
                    "LOWER(s.Patronymic) LIKE LOWER(:searchText)";

                IQuery query = session.CreateQuery(hql);
                query.SetString("searchText", $"%{text}%");

                return await query.ListAsync<Mark>();
            }
        }

        public async override Task UpdateAsync(Mark entity) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    Mark markToUpdate = session.Get<Mark>(entity.Id);
                    markToUpdate.ExamMark = entity.ExamMark;
                    markToUpdate.DefendMark = entity.DefendMark;

                    Student newStudent = session.Get<Student>(entity.Student.CreditBookNumber);
                    markToUpdate.Student = newStudent;

                    await session.UpdateAsync(markToUpdate);
                    await transaction.CommitAsync();
                }
            }
        }
    }
}
