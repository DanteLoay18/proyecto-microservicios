

using Api.Facultad.Application.Contracts.Persistence;
using Api.Facultad.Application.Utils;
using Api.Facultad.Domain.DTOs.Base;
using MediatR;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Api.Facultad.Domain.Entities;
using API.Catalogo.Domain.Constants.Base;

namespace Api.Facultad.Application.Features.Facultad.Command.UpdateFacultad
{
    public class UpdateFacultadCommandHandler : IRequestHandler<UpdateFacultadCommand, ResponseBase>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateFacultadCommandHandler> _logger;
        private readonly IUnitOfWork _uow;

        public UpdateFacultadCommandHandler(IMapper mapper, ILogger<UpdateFacultadCommandHandler> logger, IUnitOfWork uow)
        {
            _mapper = mapper;
            _logger = logger;
            _uow = uow;
        }

        public async Task<ResponseBase> Handle(UpdateFacultadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var facultadEncontrado = await _uow.Repository<Facultade>().GetAsync(x => x.Id == request.FacultadId && !x.IsDeleted );
                
                if(facultadEncontrado == null ) {
                    return ResponseUtil.NotFoundRequest(MessageConstant.NotFoundRequest);
                }

                var facultadEntity = _mapper.Map( request,facultadEncontrado );

                _uow.Repository<Facultade>().Update(facultadEntity);

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
