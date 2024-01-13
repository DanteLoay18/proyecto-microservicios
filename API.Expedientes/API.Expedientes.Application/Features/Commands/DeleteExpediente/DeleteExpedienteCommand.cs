using Api.Expedientes.Domain.DTOs.Base;
using MediatR;

namespace API.Expedientes.Application.Features.Commands.DeleteExpediente
{
    public class DeleteExpedienteCommand : IRequest<ResponseBase>
    {
        public Guid IdExpediente { get; set; }
        public string? IdUsuario { get; set; }
    }
}
