using Api.Facultad.Domain.DTOs.Base;
using MediatR;

namespace Api.Facultad.Application.Features.Facultad.Queries.GetFacultadById
{
    public class GetFacultadByIdQuery : IRequest<ResponseBase> {

        public long IdFacultad { get; set; } 

        
    }
}
