﻿
using Api.Expedientes.Application.Contracts.Persistence;
using Api.Expedientes.Infraestructure.Repositories;
using API.Expedientes.Application.Models;
using API.Expedientes.Infraestructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Api.Expedientes.Ioc.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            var mongoDbSettings = new MongoDbSettings();
            configuration.Bind(nameof(MongoDbSettings), mongoDbSettings);

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
