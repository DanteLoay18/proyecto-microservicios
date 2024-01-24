using API.Docentes.Application.Contracts.Persistence;
using API.Docentes.Application.Features.Docentes.Queries.GetDocentesPaginated;
using API.Docentes.Application.Utils;
using API.Docentes.Domain.Constants.Base;
using API.Docentes.Domain.DTOs.Base;
using API.Docentes.Domain.DTOs.Response;
using API.Docentes.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace API.Docentes.Application.Features.Docentes.Queries.GetDocenteById
{
    public class GetDocenteByIdQueryHandler : IRequestHandler<GetDocenteByIdQuery, ResponseBase>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<GetDocenteByIdQueryHandler> _logger;

        public GetDocenteByIdQueryHandler(IUnitOfWork uow, IMapper mapper, ILogger<GetDocenteByIdQueryHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetDocenteByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var docente = await _uow.Repository<Docente>().FindByIdAsync(request.IdDocente);

                if (docente != null && !docente.IsDeleted)
                {
                    var docenteDto = _mapper.Map<DocenteItemResponse>(docente);
                    return ResponseUtil.OK(docenteDto);
                }
                else if (docente != null && docente.IsDeleted)
                {
                    return ResponseUtil.NotFoundRequest($"El docente con ID {request.IdDocente} ha sido eliminado.");
                }
                else
                {
                    return ResponseUtil.NotFoundRequest($"No se encontró el docente con ID {request.IdDocente}");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
