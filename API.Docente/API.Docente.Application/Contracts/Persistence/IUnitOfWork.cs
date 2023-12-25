

namespace API.Docentes.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task SaveChangesAsync();
        Task<object> TransactionAsync(Func<Task<object>> action);
    }
}
