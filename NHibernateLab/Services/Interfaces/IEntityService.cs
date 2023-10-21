using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHibernateLab.Services.Interfaces {
    public interface IEntityService<TEntity> {
        Task Create(TEntity entity);
        Task Delete(TEntity entity);
        Task<IList<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<IList<TEntity>> Search(string text);
        Task Update(TEntity entity);
    }
}
