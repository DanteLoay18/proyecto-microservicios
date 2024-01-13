using Api.Expedientes.Domain.DTOs.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Expedientes.Application.Features.Queries.GetExpedienteById
{
    public class GetExpedienteByIdQuery : IRequest<ResponseBase>
    {
        public Guid IdExpediente {  get; set; } 
    }
}
