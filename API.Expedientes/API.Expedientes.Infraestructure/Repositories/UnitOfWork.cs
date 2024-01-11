using Api.Expedientes.Application.Contracts.Persistence;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Api.Expedientes.Infraestructure.Persistence.Extensions;

namespace Api.Expedientes.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _database;
        private readonly string _conexion;
        private readonly string _collection;
        private readonly IConfiguration _configuration;

        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
            var database = ConnectionStringExtension.GetConnectionString(configuration);
            _database = database.DatabaseName!;
            _conexion = database.ConnectionString!;
            _collection = database.CollectionName!;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            return new Repository<T>(_conexion, _database,_collection);
        }


        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }

       

        
    }
}
