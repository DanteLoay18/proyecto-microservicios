using API.Docentes.Application.Contracts.Persistence;
using API.Docentes.Application.Features.Docentes.Queries.GetDocentesPaginated;
using API.Docentes.Application.Utils;
using API.Docentes.Domain.Constants.Base;
using API.Docentes.Domain.DTOs.Base;
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
                var docentes = await _uow.Repository<Docente>().GetAllAsync(cancellationToken);

                //_logger.LogInformation("Se encontro el id de la facultad correctamente");
                return ResponseUtil.OK(1);

            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "", ex.Message);
                return ResponseUtil.InternalError();
            }
        }
    }
}
