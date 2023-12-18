using Microsoft.Extensions.Configuration;

namespace Api.Facultad.Infraestructure.Persistence.Extensions
{
    internal static class ConnectionStringExtension
    {
        internal static string GetConnectionString(IConfiguration configuration)
        {
            string? dbConnection = configuration["DbConnection"];
            if (string.IsNullOrEmpty(dbConnection)) throw new ArgumentException("Undefined database", nameof(configuration));
            return dbConnection;
        }
    }
}
