using Api.Facultad.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Facultad.Infraestructure.Configurations
{
    public class EscuelaConfiguration : IEntityTypeConfiguration<Escuela>
    {
        public void Configure(EntityTypeBuilder<Escuela> builder)
        {
            builder.HasData(
                    new Escuela { Id=1, Nombre = "ESCUELA DE INGENIERIA CIVIL", FacultadId = 1 },
                    new Escuela { Id = 2, Nombre = "ESCUELA DE INGENIERIA DE SISTEMAS", FacultadId = 1 },
                    new Escuela { Id = 3, Nombre = "ESCUELA DE ENFERMERIA", FacultadId = 2 },
                    new Escuela { Id = 4, Nombre = "ESCUELA DE PSICOLOGIA", FacultadId = 2 },
                    new Escuela { Id = 5, Nombre = "ESCUELA DE AGRONOMIA", FacultadId = 3 },
                    new Escuela { Id = 6, Nombre = "ESCUELA DE INGENIERIA AGROINDUSTRIAL", FacultadId = 3 },
                    new Escuela { Id = 7, Nombre = "ESCUELA DE INGENIERIA FORESTAL", FacultadId = 4 },
                    new Escuela { Id = 8, Nombre = "ESCUELA DE INGENIERIA AMBIENTAL", FacultadId = 4 },
                    new Escuela { Id = 9, Nombre = "ESCUELA DE MEDICINA HUMANA", FacultadId = 5 }
                );
        }

    }
}
