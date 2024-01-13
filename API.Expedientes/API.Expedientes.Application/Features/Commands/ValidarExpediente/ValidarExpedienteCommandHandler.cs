

using Api.Expedientes.Application.Contracts.Persistence;
using API.Expedientes.Application.Features.Commands.DeleteExpediente;
using Api.Expedientes.Domain.DTOs.Base;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using API.Expedientes.Application.Utils;
using Api.Expedientes.Domain.Entities;
using API.Facultad.Domain.Constants.Base;

namespace API.Expedientes.Application.Features.Commands.ValidarExpediente
{
    public class ValidarExpedienteCommandHandler : IRequestHandler<ValidarExpedienteCommand, ResponseBase>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<ValidarExpedienteCommandHandler> _logger;
        public ValidarExpedienteCommandHandler(IUnitOfWork uow, IMapper mapper, ILogger<ValidarExpedienteCommandHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(ValidarExpedienteCommand request, CancellationToken cancellationToken)
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

                var expedienteEntity = _mapper.Map(request, expedienteEncontrado);

                await _uow.Repository<Expediente>().UpdateAsync(expedienteId, expedienteEntity);


                _logger.LogInformation("Se valido el expediente correctamente");
                return ResponseUtil.OK(expedienteEntity.Id, MessageConstant.OkRequestValidate);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
