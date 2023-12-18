
using Api.Facultad.Application.Contracts.Persistence;
using Api.Facultad.Application.Features.Facultad.Queries.GetFacultadById;
using Api.Facultad.Application.Utils;
using Api.Facultad.Domain.DTOs.Base;
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

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
