using Api.Expedientes.Domain.DTOs.Base;
using API.Expedientes.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Expedientes.Application.Features.Commands.UpdateExpediente
{
    public class UpdateExpedienteCommand : IRequest<ResponseBase>
    {
        public Guid IdExpediente { get; set; }
        public int? Tipo { get; set; }
        public string? NumeroExpediente { get; set; }
        public int? IdEscuela { get; set; }
        public int? IdFacultad { get; set; }
        public bool? EsValido { get; set; }
        public ICollection<Estudiante>? Estudiantes { get; set; }
        public string? IdUsuario { get; set; }
    }
}
