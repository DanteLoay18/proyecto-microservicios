
using System.Linq.Expressions;

namespace API.Docentes.Application.Contracts.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Query Methods
        TEntity Get(Expression<Func<TEntity, bool>> expression);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);

        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);


        Task<TEntity> FindByIdAsync(object id);

        #endregion

        #region Command Methods
        void Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        void AddRange(IEnumerable<TEntity> entities);

        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        int Update(TEntity entity);

        int Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties);

        void UpdateRange(IEnumerable<TEntity> entities);

        int Delete(TEntity entity);

        int Delete(TEntity entity, params Expression<Func<TEntity, object>>[] properties);

        void DeleteRange(IEnumerable<TEntity> entities);
        #endregion
    }
}
