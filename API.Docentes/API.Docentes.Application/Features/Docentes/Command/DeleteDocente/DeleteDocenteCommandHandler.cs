

using API.Docentes.Application.Contracts.Persistence;
using API.Docentes.Application.Features.Docentes.Command.CreateDocente;
using API.Docentes.Application.Utils;
using API.Docentes.Domain.Constants.Base;
using API.Docentes.Domain.DTOs.Base;
using API.Docentes.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace API.Docentes.Application.Features.Docentes.Command.DeleteDocente
{
    public class DeleteDocenteCommandHandler : IRequestHandler<DeleteDocenteCommand, ResponseBase>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteDocenteCommandHandler> _logger;
        public DeleteDocenteCommandHandler(IUnitOfWork uow, IMapper mapper, ILogger<DeleteDocenteCommandHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(DeleteDocenteCommand request, CancellationToken cancellationToken)
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

                var docenteEntity = _mapper.Map(request, docenteEncontrado);

                _uow.Repository<Docente>().Update(docenteEntity);


                _logger.LogInformation("Se elimino el docente correctamente");
                return ResponseUtil.OK(docenteEntity.Id, MessageConstant.OkRequestDelete);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
