using NHibernate;
using NHibernateLab.Entities;
using NHibernateLab.NHibernate;
using System.Threading.Tasks;

namespace NHibernateLab.Services.Implementations {
    public class DepartmentService : EntityService<Department> {
        public override async Task UpdateAsync(Department entity) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "UPDATE Department SET name = :name  WHERE Id = :id";

                IQuery query = session.CreateQuery(hql);
                query.SetInt32("id", entity.Id);
                query.SetParameter("name", entity.Name);

                await query.ExecuteUpdateAsync();
            }
        }
    }
}
