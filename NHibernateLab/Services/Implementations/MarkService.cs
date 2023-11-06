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

        public override Task UpdateAsync(Mark entity) {
            throw new System.NotImplementedException();
        }
    }
}
