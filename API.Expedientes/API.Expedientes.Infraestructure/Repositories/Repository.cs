﻿using Api.Expedientes.Application.Contracts.Persistence;
using API.Expedientes.Infraestructure.Persistence;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Api.Expedientes.Infraestructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _collection;

        public Repository(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _collection = database.GetCollection<TEntity>(collectionName);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
        {
            return await _collection.Find(filter).ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
        {
            return await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _collection.Find(Builders<TEntity>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Guid id, TEntity entity)
        {
            await _collection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("Id", id), entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("Id", id));
        }

    }
}
