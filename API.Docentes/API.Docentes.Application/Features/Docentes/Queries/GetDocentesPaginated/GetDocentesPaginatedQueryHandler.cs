
using API.Docentes.Domain.Entities;
using API.Docentes.Application.Contracts.Persistence;
using API.Docentes.Domain.DTOs.Base;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using API.Docentes.Application.Utils;
using API.Docentes.Domain.Constants.Base;
using API.Docentes.Domain.DTOs.Response;

namespace API.Docentes.Application.Features.Docentes.Queries.GetDocentesPaginated
{
    public class GetDocentesPaginatedQueryHandler : IRequestHandler<GetDocentesPaginatedQuery, ResponseBase>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<GetDocentesPaginatedQueryHandler> _logger;
        public GetDocentesPaginatedQueryHandler(IUnitOfWork uow, IMapper mapper, ILogger<GetDocentesPaginatedQueryHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetDocentesPaginatedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var docentesEncontrados = await _uow.Repository<Docente>().GetAllAsync(x => !x.IsDeleted,cancellationToken);

                var startIndex = (request.Page - 1) * request.PageSize;
                var endIndex = startIndex + request.PageSize;
                var count = endIndex - startIndex;

               
                var slicedDocentes = docentesEncontrados.Skip(startIndex).Take(count).ToList();


                var facultadesResponse = _mapper.Map<List<DocenteItemResponse>>(slicedDocentes);

                var paginatorResponse = _mapper.Map<PaginatorResponse<DocenteItemResponse>>(source: (request.Page, request.PageSize, docentesEncontrados.ToList().Count(), facultadesResponse));

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
