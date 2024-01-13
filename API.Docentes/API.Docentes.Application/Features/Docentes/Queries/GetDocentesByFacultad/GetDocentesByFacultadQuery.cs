
using API.Docentes.Domain.DTOs.Base;
using MediatR;

namespace API.Docentes.Application.Features.Docentes.Queries.GetDocentesByFacultad
{
    public class GetDocentesByFacultadQuery : IRequest<ResponseBase>
    {
        public int IdFacultad { get; set; }
    }
}
