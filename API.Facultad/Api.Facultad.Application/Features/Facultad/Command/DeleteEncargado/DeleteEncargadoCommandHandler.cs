
using Api.Facultad.Application.Contracts.Persistence;
using Api.Facultad.Application.Utils;
using Api.Facultad.Domain.DTOs.Base;
using API.Catalogo.Domain.Constants.Base;
using Api.Facultad.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Facultad.Application.Features.Facultad.Command.DeleteEncargado
{
    public class DeleteEncargadoCommandHandler : IRequestHandler<DeleteEncargadoCommand, ResponseBase>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteEncargadoCommand> _logger;
        public DeleteEncargadoCommandHandler(IUnitOfWork uow, IMapper mapper, ILogger<DeleteEncargadoCommand> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(DeleteEncargadoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var facultadId = request.IdFacultad;
                var facultadEncontrada = await _uow.Repository<Facultade>().GetAsync(x => !x.IsDeleted && x.Id == facultadId, cancellationToken);

                if (facultadEncontrada == null)
                {
                    _logger.LogWarning($"No se encontro el id {request.IdFacultad} de la facultad");
                    return ResponseUtil.NotFoundRequest(MessageConstant.NotFoundRequest);
                }

                var facultadEntity = _mapper.Map(request, facultadEncontrada);
                _uow.Repository<Facultade>().Update(facultadEntity);//se hace update

                _logger.LogInformation("Se elimino el encargado correctamente");
                return ResponseUtil.OK(facultadEntity.Id, MessageConstant.OkRequestUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
