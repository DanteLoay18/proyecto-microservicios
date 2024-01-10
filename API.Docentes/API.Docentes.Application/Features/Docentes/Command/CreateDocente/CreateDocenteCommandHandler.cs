
using API.Docentes.Application.Contracts.Persistence;
using API.Docentes.Application.Utils;
using API.Docentes.Domain.Constants.Base;
using API.Docentes.Domain.DTOs.Base;
using API.Docentes.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace API.Docentes.Application.Features.Docentes.Command.CreateDocente
{
    public class CreateDocenteCommandHandler : IRequestHandler<CreateDocenteCommand, ResponseBase>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateDocenteCommandHandler> _logger;
        public CreateDocenteCommandHandler(IUnitOfWork uow, IMapper mapper, ILogger<CreateDocenteCommandHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CreateDocenteCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var numeroDocumentoExiste= await _uow.Repository<Docente>().GetAsync(x=> x.IsDeleted && x.IdFacultad == request.IdFacultad && x.NumeroDocumento == request.NumeroDocumento ,cancellationToken);

                if (numeroDocumentoExiste != null)
                {
                    _logger.LogWarning($"El numero de documento : ${request.NumeroDocumento} ya existe");
                    return ResponseUtil.BadRequest(MessageConstant.BadRequest);
                }

                var emailExiste = await _uow.Repository<Docente>().GetAsync(x => x.IsDeleted && x.IdFacultad == request.IdFacultad && x.Email == request.Email, cancellationToken);
                
                if (emailExiste != null)
                {
                    _logger.LogWarning($"El email : ${request.Email} ya existe");
                    return ResponseUtil.BadRequest(MessageConstant.BadRequest);
                }

                var docenteEntity = _mapper.Map<Docente>(request);

                _uow.Repository<Docente>().Add(docenteEntity);


                _logger.LogInformation("Se registro el docente correctamente");
                return ResponseUtil.OK(docenteEntity.Id, MessageConstant.OkRequestRegistro);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
