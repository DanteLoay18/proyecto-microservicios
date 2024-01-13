using Api.Expedientes.Domain.DTOs.Base;
using API.Docentes.Routes;
using API.Expedientes.Application.Features.Commands.CreateExpediente;
using API.Expedientes.Application.Features.Commands.DeleteExpediente;
using API.Expedientes.Application.Features.Commands.UpdateExpediente;
using API.Expedientes.Application.Features.Queries.GetAllExpedientes;
using API.Expedientes.Application.Features.Queries.GetExpedienteById;
using API.Expedientes.Application.Utils;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Expedientes.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Expediente.Controller)]
    public class ExpedienteController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ExpedienteController> _logger;
        private readonly IMapper _mapper;
        public ExpedienteController(IMediator mediator, ILogger<ExpedienteController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Expediente.GetExpedienteById)]
        public async Task<ActionResult<ResponseBase>> GetExpedienteById(Guid id)
        {
            try
            {
                var query = new GetExpedienteByIdQuery();
                query.IdExpediente = id;
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }

        }

        [HttpGet(ApiRoutes.Expediente.GetAllExpedientes)]
        public async Task<ActionResult<ResponseBase>> GetAllExpedientes([FromQuery] GetAllExpedientesQuery query)
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

        [HttpPost(ApiRoutes.Expediente.CreateExpediente)]
        public async Task<ActionResult<ResponseBase>> CreateExpediente([FromBody] CreateExpedienteCommand command)
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

        [HttpPut(ApiRoutes.Expediente.UpdateExpediente)]
        public async Task<ActionResult<ResponseBase>> UpdateExpediente([FromBody] UpdateExpedienteCommand command)
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

        [HttpDelete(ApiRoutes.Expediente.DeleteExpediente)]
        public async Task<ActionResult<ResponseBase>> DeleteExpediente([FromBody] DeleteExpedienteCommand command)
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
