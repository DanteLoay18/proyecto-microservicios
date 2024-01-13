

using API.Docentes.Domain.DTOs.Base;
using MediatR;

namespace API.Docentes.Application.Features.Docentes.Queries.GetDocentesByEscuela
{
    public class GetDocentesByEscuelaQuery : IRequest<ResponseBase>
    {
        public int? IdEscuela { get; set; }
    }
}
