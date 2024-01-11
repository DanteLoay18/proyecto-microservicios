using API.Expedientes.Application.Models;
using Microsoft.Extensions.Configuration;

namespace Api.Expedientes.Infraestructure.Persistence.Extensions
{
    public static class ConnectionStringExtension
    {
        public static MongoDbSettings GetConnectionString(IConfiguration configuration)
        {
            var dbConnection = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
            if (string.IsNullOrEmpty(dbConnection.ConnectionString)) throw new ArgumentException("Undefined database", nameof(configuration));
            return dbConnection;
        }
    }
}
