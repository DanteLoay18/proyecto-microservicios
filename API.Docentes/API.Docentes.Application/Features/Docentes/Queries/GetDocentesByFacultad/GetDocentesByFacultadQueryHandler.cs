
using API.Docentes.Application.Contracts.Persistence;
using API.Docentes.Application.Features.Docentes.Queries.GetDocentesByEscuela;
using API.Docentes.Application.Utils;
using API.Docentes.Domain.DTOs.Base;
using API.Docentes.Domain.DTOs.Response;
using API.Docentes.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace API.Docentes.Application.Features.Docentes.Queries.GetDocentesByFacultad
{
    public class GetDocentesByFacultadQueryHandler : IRequestHandler<GetDocentesByFacultadQuery, ResponseBase>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<GetDocentesByFacultadQueryHandler> _logger;
        public GetDocentesByFacultadQueryHandler(IUnitOfWork uow, IMapper mapper, ILogger<GetDocentesByFacultadQueryHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetDocentesByFacultadQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var docentes = await _uow.Repository<Docente>().GetAllAsync(x => x.IdFacultad == request.IdFacultad, cancellationToken);

                var docentesResponse = _mapper.Map<List<DocenteItemResponse>>(docentes);

                _logger.LogInformation("Se encontro los docentes correctamente");
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
