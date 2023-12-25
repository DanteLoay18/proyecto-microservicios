

using API.Docentes.Domain.DTOs.Base;
using MediatR;

namespace API.Docentes.Application.Features.Docentes.Queries.GetDocentesPaginated
{
    public class GetDocentesPaginatedQuery : IRequest<ResponseBase>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
