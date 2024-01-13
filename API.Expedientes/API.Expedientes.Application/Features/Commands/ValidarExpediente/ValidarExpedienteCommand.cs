
using Api.Expedientes.Domain.DTOs.Base;
using API.Expedientes.Domain.Entities;
using MediatR;

namespace API.Expedientes.Application.Features.Commands.ValidarExpediente
{
    public class ValidarExpedienteCommand : IRequest<ResponseBase>
    {
        public Guid IdExpediente { get; set; }
        public string? IdUsuario { get; set; }
    }
}
