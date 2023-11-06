using NHibernate;
using NHibernateLab.Entities;
using NHibernateLab.NHibernate;
using System.Threading.Tasks;

namespace NHibernateLab.Services.Implementations {
    public class GroupService : EntityService<Group> {
        public override async Task UpdateAsync(Group entity) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "UPDATE Group SET name = :name  WHERE Id = :id";

                IQuery query = session.CreateQuery(hql);
                query.SetInt32("id", entity.Id);
                query.SetParameter("name", entity.Name);

                await query.ExecuteUpdateAsync();
            }
        }

        public override async Task DeleteAsync(int deleteEntityId) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string sql = $"DELETE FROM students_groups WHERE id = :entityId";
                var query = session.CreateSQLQuery(sql);
                query.SetInt32("entityId", deleteEntityId);
                int rowsAffected = await query.ExecuteUpdateAsync();
            }
        }
    }
}
