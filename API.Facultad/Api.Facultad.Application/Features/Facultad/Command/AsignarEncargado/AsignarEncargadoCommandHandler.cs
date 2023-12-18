using Api.Facultad.Application.Contracts.Persistence;
using Api.Facultad.Application.Features.Facultad.Queries.GetFacultadById;
using Api.Facultad.Application.Utils;
using Api.Facultad.Domain.DTOs.Base;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Facultad.Application.Features.Facultad.Command.AsignarEncargado
{
    public class AsignarEncargadoCommandHandler : IRequestHandler<AsignarEncargadoCommand, ResponseBase>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AsignarEncargadoCommandHandler> _logger;
        public AsignarEncargadoCommandHandler(IUnitOfWork uow, IMapper mapper, ILogger<AsignarEncargadoCommandHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(AsignarEncargadoCommand request, CancellationToken cancellationToken)
        {
            try
            { 
                              
            
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
