
using System.Linq.Expressions;

namespace Api.Expedientes.Application.Contracts.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetByIdAsync(string id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(string id, TEntity entity);
        Task DeleteAsync(string id);
    }
}
