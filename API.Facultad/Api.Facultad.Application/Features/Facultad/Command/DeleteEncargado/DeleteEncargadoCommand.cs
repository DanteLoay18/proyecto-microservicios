
using Api.Facultad.Domain.DTOs.Base;
using MediatR;

namespace Api.Facultad.Application.Features.Facultad.Command.DeleteEncargado
{
    public class DeleteEncargadoCommand : RequestBase, IRequest<ResponseBase>    {
        public long IdFacultad {  get; set; }
    }
}
