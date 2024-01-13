using API.Expedientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Expedientes.Domain.DTOs.Response
{
    public class ExpedienteItemResponse
    {
        public Guid Id { get; set; }
        public int Tipo { get; set; }
        public string? NumeroExpediente { get; set; }
        public int IdEscuela { get; set; }
        public int IdFacultad { get; set; }
        public bool? EsValido { get; set; }
        public ICollection<Estudiante>? Estudiantes { get; set; }
    }
}
