

using API.Docentes.Domain.Entities;
using API.Docentes.Domain.Entities.Base;
using API.Docentes.Infraestructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace API.Docentes.Infraestructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IEnumerable<Type> _entityTypes;

        public ApplicationDbContext(
            IConfiguration configuration,
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            _configuration = configuration;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            string? assemblyName = _configuration["Domain"];
            if (string.IsNullOrWhiteSpace(assemblyName)) throw new Exception("Undefined domain layer")!;

            var assembly = Assembly.Load(assemblyName);
            var types = assembly.GetTypes();
            _entityTypes = types.Where(t => t.BaseType == typeof(BaseEntity) || t.BaseType == typeof(BaseLessEntity));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entitiesAssembly = typeof(BaseEntity).Assembly;
            modelBuilder.RegisterAllEntities(_entityTypes);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

    }
}
