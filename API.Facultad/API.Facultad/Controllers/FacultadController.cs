
using Api.Facultad.Application.Features.Facultad.Command.AsignarEncargado;
using Api.Facultad.Application.Features.Facultad.Command.DeleteEncargado;
using Api.Facultad.Application.Features.Facultad.Queries.GetEscuelasByFacultad;
using Api.Facultad.Application.Features.Facultad.Queries.GetFacultadById;
using Api.Facultad.Application.Features.Facultad.Queries.GetFacultades;
using Api.Facultad.Application.Features.Facultad.Queries.GetFacultadesPaginated;
using Api.Facultad.Application.Utils;
using Api.Facultad.Domain.DTOs.Base;
using Api.Facultad.Domain.DTOs.Request;
using API.Facultad.Routes;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Facultad.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Facultad.Controller)]
    public class FacultadController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FacultadController> _logger;
        public readonly IMapper _mapper;
        public FacultadController(IMediator mediator, ILogger<FacultadController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Facultad.FindFacultadById)]
        public async Task<ActionResult<ResponseBase>> GetFacultadById(long id)
        {
            try
            {
                var query = new GetFacultadByIdQuery();
                query.IdFacultad= id;
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }
            
        }

        [HttpGet(ApiRoutes.Facultad.FindEscuelasByFacultad)]
        public async Task<ActionResult<ResponseBase>> GetEscuelasByFacultad(long id)
        {
            try
            {
                var query = new GetEscuelasByFacultadQuery();
                query.IdFacultad = id;
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }

        }

        [HttpGet(ApiRoutes.Facultad.FindFacultadesPaginated)]
        public async Task<ActionResult<ResponseBase>> GetFacultadesPaginated([FromQuery] GetFacultadesPaginatedRequest getFacultadesPaginatedRequest)
        {
            try
            {
                var query = _mapper.Map<GetFacultadesPaginatedQuery>(getFacultadesPaginatedRequest); 
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }

        }

        [HttpGet(ApiRoutes.Facultad.FindFacultades)]
        public async Task<ActionResult<ResponseBase>> GetFacultades()
        {
            try
            {
                var query = new GetFacultadesQuery();
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }

        }

        [HttpPut(ApiRoutes.Facultad.AsignarEncargado)]
        public async Task<ActionResult<ResponseBase>> AsignarEncargado([FromBody] AsignarEncargadoRequest asignarEncargadoRequest)
        {
            try
            {
                var command = _mapper.Map<AsignarEncargadoCommand>(asignarEncargadoRequest);
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }

        }
        [HttpPut(ApiRoutes.Facultad.DeleteEncargado)]
        public async Task<ActionResult<ResponseBase>> DeleteEncargado([FromBody] DeleteEncargadoRequest deleteEncargadoRequest)
        {
            try
            {
                var command = _mapper.Map<DeleteEncargadoCommand>(deleteEncargadoRequest);
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }

        }
    }
}
