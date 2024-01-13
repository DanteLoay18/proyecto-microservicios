using API.Docentes.Application.Contracts.Persistence;
using API.Docentes.Application.Utils;
using API.Docentes.Domain.DTOs.Base;
using API.Docentes.Domain.DTOs.Response;
using API.Docentes.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;


namespace API.Docentes.Application.Features.Docentes.Queries.GetDocentesByBusqueda
{
    public class GetDocenteByBusquedaQueryHandler : IRequestHandler<GetDocentesByBusquedaQuery, ResponseBase>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<GetDocenteByBusquedaQueryHandler> _logger;

        public GetDocenteByBusquedaQueryHandler(IUnitOfWork uow, IMapper mapper, ILogger<GetDocenteByBusquedaQueryHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(GetDocentesByBusquedaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var docentesEncontrados = await _uow.Repository<Docente>()
                    .GetAllAsync(BuildSearchPredicate(request), cancellationToken);

                var startIndex = (request.Page - 1) * request.PageSize;
                var slicedDocentes = docentesEncontrados.Skip(startIndex).Take(request.PageSize).ToList();

                var docentesResponse = _mapper.Map<List<DocenteItemResponse>>(slicedDocentes);

                var paginatorResponse = new PaginatorResponse<DocenteItemResponse>
                {
                    Items = docentesResponse,
                    PageSize = request.PageSize,
                    Page = request.Page,
                    Total = docentesEncontrados.Count()
                };

                return ResponseUtil.OK(paginatorResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }

        private Expression<Func<Docente, bool>> BuildSearchPredicate(GetDocentesByBusquedaQuery request)
        {
            Expression<Func<Docente, bool>> predicate = x => !x.IsDeleted;

            if (!string.IsNullOrWhiteSpace(request.NombreCompleto))
            {
                predicate = And(predicate, x => x.NombreCompleto.Contains(request.NombreCompleto));
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                predicate = And(predicate, x => x.Email.Contains(request.Email));
            }

            if (request.IdEscuela.HasValue && request.IdEscuela > 0)
            {
                predicate = And(predicate, x => x.IdEscuela == request.IdEscuela);
            }

            if (request.IdFacultad.HasValue && request.IdFacultad > 0)
            {
                predicate = And(predicate, x => x.IdFacultad == request.IdFacultad);
            }

            return predicate;
        }

        private Expression<Func<Docente, bool>> And(Expression<Func<Docente, bool>> expr1, Expression<Func<Docente, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<Docente, bool>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
}
