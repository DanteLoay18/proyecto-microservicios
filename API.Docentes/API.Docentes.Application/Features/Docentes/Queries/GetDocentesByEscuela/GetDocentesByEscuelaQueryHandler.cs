
using API.Docentes.Application.Contracts.Persistence;
using API.Docentes.Application.Features.Docentes.Queries.GetDocentesPaginated;
using API.Docentes.Application.Utils;
using API.Docentes.Domain.DTOs.Base;
using API.Docentes.Domain.DTOs.Response;
using API.Docentes.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace API.Docentes.Application.Features.Docentes.Queries.GetDocentesByEscuela
{
    public class GetDocentesByEscuelaQueryHandler : IRequestHandler<GetDocentesByEscuelaQuery, ResponseBase>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<GetDocentesByEscuelaQueryHandler> _logger;
        public GetDocentesByEscuelaQueryHandler(IUnitOfWork uow, IMapper mapper, ILogger<GetDocentesByEscuelaQueryHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetDocentesByEscuelaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var docentes = await _uow.Repository<Docente>().GetAllAsync(x=> x.IdEscuela == request.IdEscuela ,cancellationToken);

                var docentesResponse = _mapper.Map<List<DocenteItemResponse>>(docentes);

                _logger.LogInformation("Se encontro el id de la facultad correctamente");
                return ResponseUtil.OK(docentesResponse);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
