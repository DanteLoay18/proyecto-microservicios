

using Api.Facultad.Domain.DTOs.Base;
using MediatR;

namespace Api.Facultad.Application.Features.Facultad.Command.UpdateFacultad
{
    public class UpdateFacultadCommand : RequestBase, IRequest<ResponseBase>
    {

        public long FacultadId { get; set; }
        public string Nombre { get; set; } = string.Empty;

       
    }
}
