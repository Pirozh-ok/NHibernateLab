using NHibernate;
using NHibernateLab.Entities;
using NHibernateLab.NHibernate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHibernateLab.Services.Implementations {
    public class TopicService : EntityService<Topic> {
        public override async Task<IList<Topic>> GetAllAsync() {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "FROM Topic topic " +
             "LEFT JOIN FETCH topic.Teacher teacher " +
             "LEFT JOIN FETCH topic.Student student " +
             "ORDER BY topic.Id";

                IQuery query = session.CreateQuery(hql);
                return await query.ListAsync<Topic>();
            }
        }

        public override async Task UpdateAsync(Topic entity) {
            throw new System.NotImplementedException();
        }
    }
}
