using Api.Expedientes.Application.Contracts.Persistence;
using Api.Expedientes.Domain.DTOs.Base;
using Api.Expedientes.Domain.Entities;
using API.Expedientes.Application.Utils;
using API.Facultad.Domain.Constants.Base;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Expedientes.Application.Features.Commands.CreateExpediente
{
    public class CreateExpedienteCommandHandler : IRequestHandler<CreateExpedienteCommand, ResponseBase>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateExpedienteCommandHandler> _logger;
        public CreateExpedienteCommandHandler(IUnitOfWork uow, IMapper mapper, ILogger<CreateExpedienteCommandHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CreateExpedienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var expedienteEntity = _mapper.Map<Expediente>(request);

                await _uow.Repository<Expediente>().AddAsync(expedienteEntity);
                return ResponseUtil.OK(expedienteEntity.Id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
