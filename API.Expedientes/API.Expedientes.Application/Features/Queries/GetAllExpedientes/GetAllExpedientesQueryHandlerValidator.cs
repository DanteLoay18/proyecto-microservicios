using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Expedientes.Application.Features.Queries.GetAllExpedientes
{
    public class GetAllExpedientesQueryHandlerValidator : AbstractValidator<GetAllExpedientesQuery>
    {
        public GetAllExpedientesQueryHandlerValidator()
        {
            RuleFor(p => p.Page)
                .GreaterThan(0);
            RuleFor(p => p.PageSize)
                 .GreaterThan(0);
        }
    }
}
