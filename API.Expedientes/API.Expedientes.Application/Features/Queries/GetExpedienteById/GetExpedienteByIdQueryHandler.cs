using Api.Expedientes.Application.Contracts.Persistence;
using API.Expedientes.Application.Features.Queries.GetAllExpedientes;
using Api.Expedientes.Domain.DTOs.Base;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Expedientes.Application.Utils;
using Api.Expedientes.Domain.DTOs.Response;
using API.Expedientes.Domain.DTOs.Response;
using Api.Expedientes.Domain.Entities;
using API.Facultad.Domain.Constants.Base;

namespace API.Expedientes.Application.Features.Queries.GetExpedienteById
{
    public class GetExpedienteByIdQueryHandler : IRequestHandler<GetExpedienteByIdQuery, ResponseBase>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<GetExpedienteByIdQueryHandler> _logger;
        public GetExpedienteByIdQueryHandler(IUnitOfWork uow, IMapper mapper, ILogger<GetExpedienteByIdQueryHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetExpedienteByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var expedienteId = request.IdExpediente;
                var expedienteEncontrado = await _uow.Repository<Expediente>().GetAsync(x => !x.IsDeleted && x.Id == expedienteId, cancellationToken);

                if (expedienteEncontrado == null)
                {
                    _logger.LogWarning($"No se encontro el id {expedienteId} del expediente");
                    return ResponseUtil.NotFoundRequest(MessageConstant.NotFoundRequest);
                }

                var expedienteResponse = _mapper.Map<ExpedienteItemResponse>(expedienteEncontrado);

                return ResponseUtil.OK(expedienteResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
