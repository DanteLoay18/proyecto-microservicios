using Api.Facultad.Application.Contracts.Persistence;
using Api.Facultad.Domain.Entities.Base;
using Api.Facultad.Infraestructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Facultad.Infraestructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly string _connectionString;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _entitySet;

        public Repository(ApplicationDbContext context, string connectionString)
        {
            _context = context;
            _entitySet = _context.Set<TEntity>();
            _connectionString = connectionString;
        }

        #region Query Methods
        public TEntity? Get(Expression<Func<TEntity, bool>> expression)
            => _entitySet.AsNoTracking().FirstOrDefault(expression);

        public IEnumerable<TEntity> GetAll()
            => _entitySet.AsNoTracking().AsEnumerable();

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            //AddIsDeletedCondition(ref expression);
            return _entitySet.AsNoTracking().Where(expression).AsEnumerable();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _entitySet.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            //AddIsDeletedCondition(ref expression);
            return await _entitySet.AsNoTracking().Where(expression).ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            //AddIsDeletedCondition(ref expression);
            return await _entitySet.AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);
        }

       
        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }


        
        #endregion

        #region Command Methods
        public void Add(TEntity entity)
        {
            ConfigureAuditForInsert(entity);
            _context.Add(entity);
            _context.SaveChanges();
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            ConfigureAuditForInsert(entity);
            await _context.AddAsync(entity, cancellationToken);
            _context.SaveChanges();
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.AddRange(entities);
            _context.SaveChanges();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _context.AddRangeAsync(entities, cancellationToken);
            _context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            ConfigureAuditForUpdate(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public int Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            ConfigureAuditForUpdate(entity);
            ConfigureProperties(entity, properties);
            return _context.SaveChanges();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(e => ConfigureAuditForUpdate(e));
            _context.UpdateRange(entities);
            _context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            ConfigureAuditForDelete(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public int Delete(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            ConfigureAuditForDelete(entity);
            ConfigureProperties(entity, properties);
            return _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(e => ConfigureAuditForDelete(e));
            _context.UpdateRange(entities);
            _context.SaveChanges();
        }

        #endregion

        #region Private Methods
        private void ConfigureProperties(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            foreach (var selector in properties)
            {
                _context.Entry(entity).Property(selector).IsModified = true;
            }
        }

        private void ConfigureAuditForInsert(TEntity entity)
        {
            Exception exception = new Exception("Incomplete audit fields for insert");

            var createdBy = typeof(TEntity).GetProperty(nameof(AuditEntity.CreatedBy));
            if (createdBy is null || string.IsNullOrWhiteSpace(createdBy.GetValue(entity)?.ToString())) throw exception;

            var createdFrom = typeof(TEntity).GetProperty(nameof(AuditEntity.CreatedFrom));
            if (createdFrom is null || string.IsNullOrWhiteSpace(createdFrom.GetValue(entity)?.ToString())) throw exception;

            var createdAt = typeof(TEntity).GetProperty(nameof(AuditEntity.CreatedAt));
            createdAt?.SetValue(entity, DateTime.Now);

            var isDeleted = typeof(TEntity).GetProperty(nameof(BaseEntity.IsDeleted));
            isDeleted?.SetValue(entity, false);
        }

        private void ConfigureAuditForUpdate(TEntity entity)
        {
            Exception exception = new Exception("Incomplete audit fields for update");

            var modifiedBy = typeof(TEntity).GetProperty(nameof(AuditEntity.ModifiedBy));
            if (modifiedBy is null || string.IsNullOrWhiteSpace(modifiedBy.GetValue(entity)?.ToString())) throw exception;

            var modifiedFrom = typeof(TEntity).GetProperty(nameof(AuditEntity.ModifiedFrom));
            if (modifiedFrom is null || string.IsNullOrWhiteSpace(modifiedFrom.GetValue(entity)?.ToString())) throw exception;

            var modifiedAt = typeof(TEntity).GetProperty(nameof(AuditEntity.ModifiedAt));
            modifiedAt?.SetValue(entity, DateTime.Now);
        }

        private void ConfigureAuditForDelete(TEntity entity)
        {
            Exception exception = new Exception("Incomplete audit fields for delete");

            var modifiedBy = typeof(TEntity).GetProperty(nameof(AuditEntity.ModifiedBy));
            if (modifiedBy is null || string.IsNullOrWhiteSpace(modifiedBy.GetValue(entity)?.ToString())) throw exception;

            var modifiedFrom = typeof(TEntity).GetProperty(nameof(AuditEntity.ModifiedFrom));
            if (modifiedFrom is null || string.IsNullOrWhiteSpace(modifiedFrom.GetValue(entity)?.ToString())) throw exception;

            var modifiedAt = typeof(TEntity).GetProperty(nameof(AuditEntity.ModifiedAt));
            modifiedAt?.SetValue(entity, DateTime.Now);

            var isDeleted = typeof(TEntity).GetProperty(nameof(BaseEntity.IsDeleted));
            isDeleted?.SetValue(entity, true);
        }

        private SqlConnection CreateConnection() => new SqlConnection(_connectionString);


        #endregion

        

        


        

    }
}
