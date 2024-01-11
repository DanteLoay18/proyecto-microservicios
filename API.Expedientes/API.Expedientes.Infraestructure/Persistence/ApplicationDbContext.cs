

using Api.Expedientes.Domain.Entities;
using Api.Expedientes.Domain.Entities.Base;
using Api.Expedientes.Infraestructure.Persistence.Extensions;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace Api.Expedientes.Infraestructure.Persistence
{
    public class ApplicationDbContext 
    {
        private readonly IConfiguration _configuration;
        private readonly IEnumerable<Type> _entityTypes;


    }
}
