
using Api.Expedientes.Domain.Entities.Base;
using API.Expedientes.Domain.Entities;

namespace Api.Expedientes.Domain.Entities
{

    public class Expediente : BaseEntity
    {
        public int Tipo { get; set; }
        public string? NumeroExpediente { get; set; }
        public int IdEscuela { get; set; }
        public int IdFacultad { get; set; }
        public bool? EsValido { get; set; }
        public ICollection<Estudiante>? Estudiantes { get; set; } 

    }
}
