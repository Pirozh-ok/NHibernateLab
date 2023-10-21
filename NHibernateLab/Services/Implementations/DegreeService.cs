using NHibernate;
using NHibernateLab.Entities;
using NHibernateLab.NHibernate;
using NHibernateLab.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHibernateLab.Services.Implementations {
    public class DegreeService : IEntityService<Degree> {
        public async Task Create(Degree entity) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                await session.SaveAsync(entity);
            }
        }

        public async Task Delete(Degree entity) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                await session.DeleteAsync(entity);
            }
        }

        public async Task<IList<Degree>> GetAll() {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "FROM Degree";
                IQuery query = session.CreateQuery(hql);
                return await query.ListAsync<Degree>();
            }
        }

        public async Task<Degree> GetById(int id) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "FROM Degree WHERE Id = :id";

                IQuery query = session.CreateQuery(hql);
                query.SetInt32("id", id);

                return await query.UniqueResultAsync<Degree>();
            }
        }

        public async Task<IList<Degree>> Search(string text) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "FROM YourEntity WHERE name LIKE :text";

                IQuery query = session.CreateQuery(hql);
                query.SetString("text", $"%{text}%");

                return await query.ListAsync<Degree>();
            }
        }

        public async Task Update(Degree entity) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "UPDATE YourEntity SET name = :name  WHERE Id = :id";

                IQuery query = session.CreateQuery(hql);
                query.SetInt32("id", entity.Id);
                query.SetParameter("name", entity.Name);

                await query.ExecuteUpdateAsync();
            }
        }
    }
}
