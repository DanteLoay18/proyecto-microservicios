

using API.Docentes.Domain.DTOs.Base;
using MediatR;

namespace API.Docentes.Application.Features.Docentes.Queries.GetDocenteById
{
    public class GetDocenteByIdQuery : IRequest<ResponseBase>
    {
        public long IdDocente { get; set; }
    }
}
