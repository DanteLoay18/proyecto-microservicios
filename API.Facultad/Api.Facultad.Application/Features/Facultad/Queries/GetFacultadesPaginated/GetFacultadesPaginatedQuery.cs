
using Api.Facultad.Domain.DTOs.Base;
using MediatR;

namespace Api.Facultad.Application.Features.Facultad.Queries.GetFacultadesPaginated
{
    public class GetFacultadesPaginatedQuery : IRequest<ResponseBase>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
