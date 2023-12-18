using Api.Facultad.Application.Contracts.Persistence;
using Api.Facultad.Infraestructure.Persistence;
using Api.Facultad.Infraestructure.Persistence.Extensions;
using Microsoft.Extensions.Configuration;

namespace Api.Facultad.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _appDbContext;

        public UnitOfWork(IConfiguration configuration, ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            return new Repository<T>(_appDbContext, ConnectionStringExtension.GetConnectionString(_configuration));
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _appDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<object> TransactionAsync(Func<Task<object>> action)
        {
            using var transaction = _appDbContext.Database.BeginTransaction();
            try
            {
                var result = await action();
                await SaveChangesAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }
    }
}
