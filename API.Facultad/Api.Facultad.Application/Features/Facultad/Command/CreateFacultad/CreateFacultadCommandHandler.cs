using Api.Facultad.Application.Contracts.Persistence;
using Api.Facultad.Application.Utils;
using Api.Facultad.Domain.DTOs.Base;
using Api.Facultad.Domain.Entities;
using API.Catalogo.Domain.Constants.Base;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Facultad.Application.Features.Facultad.Command.CreateFacultad
{
    public class CreateFacultadCommandHandler : IRequestHandler<CreateFacultadCommand, ResponseBase>
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<CreateFacultadCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateFacultadCommandHandler(IUnitOfWork uow, ILogger<CreateFacultadCommandHandler> logger, IMapper mapper)
        {
            _uow = uow;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(CreateFacultadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var facultadEntity = _mapper.Map<Facultade>(request);

                await _uow.Repository<Facultade>().AddAsync(facultadEntity);

                return ResponseUtil.OK(facultadEntity.Id, MessageConstant.OkRequestRegistro);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
           

        }
    }
}
