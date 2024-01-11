

using Api.Expedientes.Domain.DTOs.Base;
using API.Expedientes.Domain.Entities;
using MediatR;

namespace API.Expedientes.Application.Features.Commands.CreateExpediente
{
    public class CreateExpedienteCommand : IRequest<ResponseBase>
    {
        public int Tipo { get; set; }
        public string? NumeroExpediente { get; set; }
        public int IdEscuela { get; set; }
        public int IdFacultad { get; set; }
        public bool? EsValido { get; set; }
        public ICollection<Estudiante>? Estudiantes { get; set; }
        public string? IdUsuario { get; set; }
    }
}
