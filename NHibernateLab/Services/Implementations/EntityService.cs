using NHibernate;
using NHibernateLab.Entities;
using NHibernateLab.NHibernate;
using NHibernateLab.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHibernateLab.Services.Implementations {
    public abstract class EntityService<TEntity> : IEntityService<TEntity>
        where TEntity : IEntity, new() {
        public async Task CreateAsync(TEntity entity) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                await session.SaveAsync(entity);
            }
        }

        public async Task DeleteAsync(TEntity entity) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                await session.DeleteAsync(entity);
            }
        }

        public async Task<IList<TEntity>> GetAllAsync() {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = $"FROM {EntityType}";
                IQuery query = session.CreateQuery(hql);
                return await query.ListAsync<TEntity>();
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(int id) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = $"FROM {EntityType} WHERE Id = :id";

                IQuery query = session.CreateQuery(hql);
                query.SetInt32("id", id);

                return await query.UniqueResultAsync<TEntity>();
            }
        }

        public virtual async Task<IList<TEntity>> SearchAsync(string text) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = $"FROM {EntityType} WHERE name LIKE :text";

                IQuery query = session.CreateQuery(hql);
                query.SetString("text", $"%{text}%");

                return await query.ListAsync<TEntity>();
            }
        }

        public abstract Task UpdateAsync(TEntity entity);

        private string EntityType {
            get => typeof(TEntity).Name;
        }
    }
}
