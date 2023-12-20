using Api.Facultad.Domain.DTOs.Base;
using MediatR;

namespace Api.Facultad.Application.Features.Facultad.Queries.GetEscuelasByFacultad
{
    public class GetEscuelasByFacultadQuery : IRequest<ResponseBase>
    {
        public long IdFacultad { get; set; }
    }
}
