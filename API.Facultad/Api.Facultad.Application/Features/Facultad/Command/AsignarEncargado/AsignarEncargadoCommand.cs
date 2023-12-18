using Api.Facultad.Domain.DTOs.Base;
using MediatR;

namespace Api.Facultad.Application.Features.Facultad.Command.AsignarEncargado
{
    public class AsignarEncargadoCommand : RequestBase, IRequest<ResponseBase>
    {
        public string IdEncargado { get; set; } = string.Empty;
        public string IdFacultad { get; set; } = string.Empty;

    }
}
