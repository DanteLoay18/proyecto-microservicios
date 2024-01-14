using Api.Expedientes.Application.Contracts.Persistence;
using API.Expedientes.Application.Utils;
using Api.Expedientes.Domain.DTOs.Base;
using Api.Expedientes.Domain.DTOs.Response;
using API.Expedientes.Domain.DTOs.Response;
using Api.Expedientes.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Expedientes.Application.Features.Queries.GetExpedienteByBusqueda
{
    public class GetExpedienteByBusquedaQueryHandler : IRequestHandler<GetExpedienteByBusquedaQuery, ResponseBase>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<GetExpedienteByBusquedaQueryHandler> _logger;

        public GetExpedienteByBusquedaQueryHandler(IUnitOfWork uow, IMapper mapper, ILogger<GetExpedienteByBusquedaQueryHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetExpedienteByBusquedaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var expedientesQuery = await _uow.Repository<Expediente>().GetAllAsync(x => !x.IsDeleted, cancellationToken);

                // Filtrar por parámetros opcionales si están presentes
                if (!string.IsNullOrEmpty(request.Escuela))
                {
                    expedientesQuery = expedientesQuery.Where(x => x.IdEscuela.ToString().Contains(request.Escuela, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(request.NumeroDeExpediente))
                {
                    expedientesQuery = expedientesQuery.Where(x => x.NumeroExpediente != null && x.NumeroExpediente.Contains(request.NumeroDeExpediente, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(request.Facultad))
                {
                    expedientesQuery = expedientesQuery.Where(x => x.IdFacultad.ToString().Contains(request.Facultad, StringComparison.OrdinalIgnoreCase));
                }

                // Resto del código de paginación y respuesta
                var startIndex = (request.Page - 1) * request.PageSize;
                var count = request.PageSize;

                var expedientesEncontrados = expedientesQuery.Skip(startIndex).Take(count).ToList();

                var expedientesResponse = _mapper.Map<List<ExpedienteItemResponse>>(expedientesEncontrados);

                var paginatorResponse = _mapper.Map<PaginatorResponse<ExpedienteItemResponse>>(
                    source: (request.Page, request.PageSize, expedientesEncontrados.Count(), expedientesResponse));

                return ResponseUtil.OK(paginatorResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
