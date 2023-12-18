using Api.Facultad.Domain.DTOs.Base;
using MediatR;

namespace Api.Facultad.Application.Features.Facultad.Command.CreateFacultad
{
    public class CreateFacultadCommand : RequestBase, IRequest<ResponseBase>
    {
        public string Nombre { get; set; } = string.Empty;

    }
}
