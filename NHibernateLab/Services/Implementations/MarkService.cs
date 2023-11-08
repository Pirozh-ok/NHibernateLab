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
                    "LEFT JOIN FETCH t.Student s " +
                    "WHERE " +
                    "LOWER(m.DefendMark) LIKE LOWER(:searchText) OR " +
                    "LOWER(m.ExamMark) LIKE LOWER(:searchText) OR " +
                    "LOWER(s.FirstName) LIKE LOWER(:searchText) OR " +
                    "LOWER(s.LastName) LIKE LOWER(:searchText) OR " +
                    "LOWER(s.Patronymic) LIKE LOWER(:searchText)";

                IQuery query = session.CreateQuery(hql);
                query.SetString("searchText", $"%{text}%");

                return await query.ListAsync<Mark>();
            }
        }

        public override Task UpdateAsync(Mark entity) {
            throw new System.NotImplementedException();
        }
    }
}
