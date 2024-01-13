using Api.Expedientes.Application.Contracts.Persistence;
using API.Expedientes.Application.Features.Commands.CreateExpediente;
using Api.Expedientes.Domain.DTOs.Base;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Expedientes.Application.Utils;
using Api.Expedientes.Domain.Entities;
using Api.Expedientes.Domain.DTOs.Response;
using API.Expedientes.Domain.DTOs.Response;

namespace API.Expedientes.Application.Features.Queries.GetAllExpedientes
{
    public class GetAllExpedientesQueryHandler : IRequestHandler<GetAllExpedientesQuery, ResponseBase>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllExpedientesQueryHandler> _logger;
        public GetAllExpedientesQueryHandler(IUnitOfWork uow, IMapper mapper, ILogger<GetAllExpedientesQueryHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetAllExpedientesQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var expedientesEncontrados = await _uow.Repository<Expediente>().GetAllAsync(x => !x.IsDeleted, cancellationToken);

                var startIndex = (request.Page - 1) * request.PageSize;
                var endIndex = startIndex + request.PageSize;
                var count = endIndex - startIndex;


                var slicedExpedientes = expedientesEncontrados.Skip(startIndex).Take(count).ToList();


                var expedientesResponse = _mapper.Map<List<ExpedienteItemResponse>>(slicedExpedientes);

                var paginatorResponse = _mapper.Map<PaginatorResponse<ExpedienteItemResponse>>(source: (request.Page, request.PageSize, expedientesEncontrados.ToList().Count(), expedientesResponse));

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
