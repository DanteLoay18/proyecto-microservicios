using Api.Expedientes.Application.Contracts.Persistence;
using API.Expedientes.Application.Features.Commands.CreateExpediente;
using Api.Expedientes.Domain.DTOs.Base;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using API.Expedientes.Application.Utils;
using API.Facultad.Domain.Constants.Base;
using Api.Expedientes.Domain.Entities;

namespace API.Expedientes.Application.Features.Commands.UpdateExpediente
{
    public class UpdateExpedienteCommandHandler : IRequestHandler<UpdateExpedienteCommand, ResponseBase>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateExpedienteCommandHandler> _logger;
        public UpdateExpedienteCommandHandler(IUnitOfWork uow, IMapper mapper, ILogger<UpdateExpedienteCommandHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(UpdateExpedienteCommand request, CancellationToken cancellationToken)
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


                _logger.LogInformation("Se modifico el expediente correctamente");
                return ResponseUtil.OK(expedienteEntity.Id, MessageConstant.OkRequestUpdate);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
