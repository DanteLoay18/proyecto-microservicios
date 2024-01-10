


using API.Docentes.Application.Contracts.Persistence;
using API.Docentes.Application.Utils;
using API.Docentes.Domain.Constants.Base;
using API.Docentes.Domain.DTOs.Base;
using API.Docentes.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace API.Docentes.Application.Features.Docentes.Command.UpdateDocente
{
    public class UpdateDocenteCommandHandler : IRequestHandler<UpdateDocenteCommand, ResponseBase>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateDocenteCommandHandler> _logger;
        public UpdateDocenteCommandHandler(IUnitOfWork uow, IMapper mapper, ILogger<UpdateDocenteCommandHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(UpdateDocenteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var docenteId = request.IdDocente;

                var docenteEncontrado = await _uow.Repository<Docente>().GetAsync(x => !x.IsDeleted && x.Id == docenteId, cancellationToken);

                if (docenteEncontrado == null)
                {
                    _logger.LogWarning($"No se encontro el id {request.IdDocente} del docente");
                    return ResponseUtil.NotFoundRequest(MessageConstant.NotFoundRequest);
                }

                var numeroDocumentoExiste = await _uow.Repository<Docente>().GetAsync(x => x.IsDeleted && x.IdFacultad == request.IdFacultad && x.NumeroDocumento == request.NumeroDocumento && x.Id == request.IdDocente, cancellationToken);

                if (numeroDocumentoExiste != null)
                {
                    _logger.LogWarning($"El numero de documento : ${request.NumeroDocumento} ya existe");
                    return ResponseUtil.BadRequest(MessageConstant.BadRequest);
                }

                var emailExiste = await _uow.Repository<Docente>().GetAsync(x => x.IsDeleted && x.IdFacultad == request.IdFacultad && x.Email == request.Email && x.Id == request.IdDocente, cancellationToken);

                if (emailExiste != null)
                {
                    _logger.LogWarning($"El email : ${request.Email} ya existe");
                    return ResponseUtil.BadRequest(MessageConstant.BadRequest);
                }

                var docenteEntity = _mapper.Map(request, docenteEncontrado);

                _uow.Repository<Docente>().Update(docenteEntity);


                _logger.LogInformation("Se modifico el docente correctamente");
                return ResponseUtil.OK(docenteEntity.Id, MessageConstant.OkRequestUpdate);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
