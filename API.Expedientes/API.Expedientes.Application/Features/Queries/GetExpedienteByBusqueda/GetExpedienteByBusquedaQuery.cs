using Api.Expedientes.Domain.DTOs.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Expedientes.Application.Features.Queries.GetExpedienteByBusqueda
{
    public class GetExpedienteByBusquedaQuery : IRequest<ResponseBase>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int? Tipo { get; set; }
        public string? Escuela { get; set; }
        public string? NumeroDeExpediente { get; set; }
        public string? Facultad { get; set; }
    }
}
