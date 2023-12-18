using Api.Facultad.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Facultad.Infraestructure.Configurations
{
    public class FacultadConfiguration : IEntityTypeConfiguration<Facultade>
    {
        public void Configure(EntityTypeBuilder<Facultade> builder)
        {
            builder.HasData(
                    new Facultade { Id = 1, Nombre = "FACULTAD DE INGENIERIA DE SISTEMAS E INGENIERIA CIVIL", Encargado = null, IsDeleted = false, CreatedBy = "Dante", CreatedAt = new DateTime(), CreatedFrom = "migration" },
                    new Facultade { Id = 2, Nombre = "FACULTAD DE CIENCIAS DE LA SALUD", Encargado = null, IsDeleted = false, CreatedBy = "Dante", CreatedAt = new DateTime(), CreatedFrom = "migration" },
                    new Facultade { Id = 3, Nombre = "FACULTAD DE CIENCIAS AGROPECUARIAS", Encargado = null, IsDeleted = false, CreatedBy = "Dante", CreatedAt = new DateTime(), CreatedFrom = "migration" },
                    new Facultade { Id = 4, Nombre = "FACULTAD DE CIENCIAS FORESTAS Y AMBIENTALES", Encargado = null, IsDeleted = false, CreatedBy = "Dante", CreatedAt = new DateTime(), CreatedFrom = "migration" },
                    new Facultade { Id = 5, Nombre = "FACULTAD DE MEDICINA HUMANA", Encargado = null, IsDeleted = false, CreatedBy = "Dante", CreatedAt = new DateTime(), CreatedFrom = "migration" }
                );
        }
    }
}
