using Api.Facultad.Application.Contracts.Persistence;
using Api.Facultad.Application.Utils;
using Api.Facultad.Domain.DTOs.Base;
using API.Catalogo.Domain.Constants.Base;
using Api.Facultad.Domain.DTOs.Response;
using Api.Facultad.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Facultad.Application.Features.Facultad.Queries.GetFacultades
{
    public class GetFacultadesQueryHandler : IRequestHandler<GetFacultadesQuery, ResponseBase>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<GetFacultadesQueryHandler> _logger;
        public GetFacultadesQueryHandler(IUnitOfWork uow, IMapper mapper, ILogger<GetFacultadesQueryHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetFacultadesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var facultadesEncontradas = await _uow.Repository<Facultade>().GetAllAsync(x => !x.IsDeleted, cancellationToken);


                if (facultadesEncontradas.Any())
                {
                    foreach (var facultad in facultadesEncontradas)
                    {
                        var escuelasEncontradas = await _uow.Repository<Escuela>().GetAllAsync(x => x.FacultadId == facultad.Id, cancellationToken);

                        facultad.Escuelas = escuelasEncontradas.ToList();

                    }

                    var facultadesResponse = _mapper.Map<List<FacultadItemResponse>>(facultadesEncontradas);

                    return ResponseUtil.OK(facultadesResponse);

                }

                _logger.LogInformation("No se encontro facultades");
                return ResponseUtil.NoContent(MessageConstant.NoContentForRequest);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
