using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Docentes.Application.Features.Docentes.Queries.GetDocentesByBusqueda
{
    internal class GetDocentesByBusquedaQueryValidator : AbstractValidator<GetDocentesByBusquedaQuery>
    {
        public GetDocentesByBusquedaQueryValidator()
        {
            RuleFor(p => p.Page).GreaterThan(0);
            RuleFor(p => p.PageSize).GreaterThan(0);
        }
    }
}
