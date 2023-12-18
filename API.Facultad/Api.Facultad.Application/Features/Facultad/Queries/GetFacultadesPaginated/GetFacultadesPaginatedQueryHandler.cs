
using Api.Facultad.Application.Contracts.Persistence;
using Api.Facultad.Application.Utils;
using Api.Facultad.Domain.DTOs.Base;
using Api.Facultad.Domain.DTOs.Response;
using Api.Facultad.Domain.Entities;
using API.Catalogo.Domain.Constants.Base;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;

namespace Api.Facultad.Application.Features.Facultad.Queries.GetFacultadesPaginated
{
    public class GetFacultadesPaginatedQueryHandler : IRequestHandler<GetFacultadesPaginatedQuery, ResponseBase>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<GetFacultadesPaginatedQueryHandler> _logger;
        public GetFacultadesPaginatedQueryHandler(IUnitOfWork uow, IMapper mapper, ILogger<GetFacultadesPaginatedQueryHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetFacultadesPaginatedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var facultadesEncontradas = await _uow.Repository<Facultade>().GetAllAsync(x=> !x.IsDeleted, cancellationToken);

                var startIndex =(request.Page-1)*request.PageSize;
                var endIndex = startIndex + request.PageSize;
                var count = endIndex - startIndex; // Calcula cuántos elementos tomar



                if (facultadesEncontradas.Any())
                {
                    var slicedFacultades = facultadesEncontradas.Skip(startIndex).Take(count).ToList();

                    foreach (var facultad in slicedFacultades)
                    {
                        var escuelasEncontradas = await _uow.Repository<Escuela>().GetAllAsync(x => x.FacultadId == facultad.Id, cancellationToken);

                        facultad.Escuelas = escuelasEncontradas.ToList();

                    }

                    var facultadesResponse = _mapper.Map<List<FacultadItemResponse>>(slicedFacultades);

                    var paginatorResponse = _mapper.Map<PaginatorResponse<FacultadItemResponse>>(source: (request.Page, request.PageSize, facultadesEncontradas.ToList().Count(), facultadesResponse));

                    return ResponseUtil.OK(paginatorResponse);


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
