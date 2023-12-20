
using Api.Facultad.Application.Features.Facultad.Command.AsignarEncargado;
using Api.Facultad.Application.Features.Facultad.Command.DeleteEncargado;
using Api.Facultad.Application.Features.Facultad.Queries.GetEscuelasByFacultad;
using Api.Facultad.Application.Features.Facultad.Queries.GetFacultadById;
using Api.Facultad.Application.Features.Facultad.Queries.GetFacultades;
using Api.Facultad.Application.Features.Facultad.Queries.GetFacultadesPaginated;
using Api.Facultad.Application.Utils;
using Api.Facultad.Domain.DTOs.Base;
using API.Facultad.Routes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Facultad.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Facultad.Controller)]
    public class FacultadController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FacultadController> _logger;
        public FacultadController(IMediator mediator, ILogger<FacultadController> logger)
        {
            _mediator = mediator;
            _logger = logger;
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
        public async Task<ActionResult<ResponseBase>> GetFacultadesPaginated([FromQuery] GetFacultadesPaginatedQuery query)
        {
            try
            {
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
        public async Task<ActionResult<ResponseBase>> AsignarEncargado([FromBody] AsignarEncargadoCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }

        }
        [HttpPut(ApiRoutes.Facultad.DeleteEncargado)]
        public async Task<ActionResult<ResponseBase>> DeleteEncargado([FromBody] DeleteEncargadoCommand command)
        {
            try
            {
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
