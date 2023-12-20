using Api.Facultad.Application.Contracts.Persistence;
using Api.Facultad.Application.Utils;
using Api.Facultad.Domain.DTOs.Base;
using API.Catalogo.Domain.Constants.Base;
using Api.Facultad.Domain.DTOs.Response;
using Api.Facultad.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Facultad.Application.Features.Facultad.Queries.GetEscuelasByFacultad
{
    public class GetEscuelasByFacultadQueryHandler : IRequestHandler<GetEscuelasByFacultadQuery, ResponseBase>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEscuelasByFacultadQueryHandler> _logger;
        public GetEscuelasByFacultadQueryHandler(IUnitOfWork uow, IMapper mapper, ILogger<GetEscuelasByFacultadQueryHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponseBase> Handle(GetEscuelasByFacultadQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var facultadId = request.IdFacultad;
                var facultadEncontrada = await _uow.Repository<Facultade>().GetAsync(x => !x.IsDeleted && x.Id == facultadId, cancellationToken);

                if (facultadEncontrada == null)
                {
                    _logger.LogWarning($"No se encontro el id {request.IdFacultad} de la facultad ");
                    return ResponseUtil.NotFoundRequest(MessageConstant.NotFoundRequest);
                }

                var escuelasEncontradas = await _uow.Repository<Escuela>().GetAllAsync(x => x.FacultadId == facultadId, cancellationToken);

                var escuelasResponse = _mapper.Map<List<EscuelaItemResponse>>(escuelasEncontradas);

                _logger.LogInformation("Se encontro el id de la facultad correctamente");
                return ResponseUtil.OK(escuelasResponse);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
