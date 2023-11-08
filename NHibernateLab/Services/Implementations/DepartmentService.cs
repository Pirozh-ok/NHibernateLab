using NHibernate;
using NHibernateLab.Entities;
using NHibernateLab.NHibernate;
using System.Data.Common;
using System.Threading.Tasks;
using System.Transactions;

namespace NHibernateLab.Services.Implementations {
    public class DepartmentService : EntityService<Department> {
        public override async Task UpdateAsync(Department entity) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    var departmentToUpdate = session.Get<Department>(entity.Id);
                    departmentToUpdate.Name = entity.Name;

                    await session.UpdateAsync(departmentToUpdate);
                    await transaction.CommitAsync();
                }
            }
        }
    }
}
