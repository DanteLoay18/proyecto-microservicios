using Api.Expedientes.Domain.DTOs.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Expedientes.Application.Features.Queries.GetAllExpedientes
{
    public class GetAllExpedientesQuery : IRequest<ResponseBase>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
