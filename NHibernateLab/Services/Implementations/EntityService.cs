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

        public virtual async Task DeleteAsync(int deleteEntityId) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = $"DELETE FROM {EntityType} WHERE id = :entityId";
                var query = session.CreateQuery(hql);
                query.SetInt32("entityId", deleteEntityId);
                int rowsAffected = await query.ExecuteUpdateAsync();
            }
        }

        public virtual async Task<IList<TEntity>> GetAllAsync() {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = $"FROM {EntityType} ORDER BY Id";
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
                string hql = $"FROM {EntityType} WHERE LOWER(name) LIKE LOWER(:text)";

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
