using NHibernateLab.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHibernateLab.Services.Interfaces {
    public interface IEntityService<TEntity> where TEntity : IEntity, new() {
        Task CreateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<IList<TEntity>> SearchAsync(string text);
        Task UpdateAsync(TEntity entity);
    }
}
