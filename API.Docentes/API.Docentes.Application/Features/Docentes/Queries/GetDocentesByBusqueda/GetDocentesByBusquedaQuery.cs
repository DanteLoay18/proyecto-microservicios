using API.Docentes.Domain.DTOs.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Docentes.Application.Features.Docentes.Queries.GetDocentesByBusqueda
{
    public class GetDocentesByBusquedaQuery : IRequest<ResponseBase>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Email { get; set; }
        public int? IdEscuela { get; set; }
        public int? IdFacultad { get; set; }
    }
}
