
using Api.Facultad.Application.Contracts.Persistence;
using Api.Facultad.Infraestructure.Persistence;
using Api.Facultad.Infraestructure.Persistence.Extensions;
using Api.Facultad.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            string? dbConnection = ConnectionStringExtension.GetConnectionString(configuration);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dbConnection));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            AddRepositories(services);
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(t => t.Name.EndsWith("Repository")).ToList();

            foreach (var type in types)
            {
                var interfaceType = type.GetInterfaces().FirstOrDefault(i => i.Name == $"I{type.Name}");
                if (interfaceType != null && !services.Any(x => x.ServiceType == interfaceType))
                {
                    services.AddScoped(interfaceType, type);
                }
            }
        }
    }
}
