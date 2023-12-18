
using FluentValidation;

namespace Api.Facultad.Application.Features.Facultad.Queries.GetFacultadesPaginated
{
    public class GetFacultadesPaginatedQueryValidator : AbstractValidator<GetFacultadesPaginatedQuery>
    {

        public GetFacultadesPaginatedQueryValidator()
        {
            RuleFor(p => p.Page)
                 .GreaterThan(0);
            RuleFor(p => p.PageSize)
                 .GreaterThan(0);
        }
    }
}
