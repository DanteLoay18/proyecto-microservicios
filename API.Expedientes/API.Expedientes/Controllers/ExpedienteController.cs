using Api.Expedientes.Domain.DTOs.Base;
using API.Docentes.Routes;
using API.Expedientes.Application.Features.Commands.CreateExpediente;
using API.Expedientes.Application.Utils;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpPost(ApiRoutes.Expediente.CreateExpediente)]
        public async Task<ActionResult<ResponseBase>> CreateDocente([FromBody] CreateExpedienteCommand command)
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
