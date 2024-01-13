using API.Docentes.Application.Features.Docentes.Command.CreateDocente;
using API.Docentes.Application.Features.Docentes.Command.DeleteDocente;
using API.Docentes.Application.Features.Docentes.Command.UpdateDocente;
using API.Docentes.Application.Features.Docentes.Queries.GetDocenteById;
using API.Docentes.Application.Features.Docentes.Queries.GetDocentesByEscuela;
using API.Docentes.Application.Features.Docentes.Queries.GetDocentesByFacultad;
using API.Docentes.Application.Features.Docentes.Queries.GetDocentesPaginated;
using API.Docentes.Application.Utils;
using API.Docentes.Domain.DTOs.Base;
using API.Docentes.Domain.DTOs.Request;
using API.Docentes.Routes;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Docentes.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Docente.Controller)]
    public class DocenteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DocenteController> _logger;
        private readonly IMapper _mapper;
        public DocenteController(IMediator mediator, ILogger<DocenteController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet(ApiRoutes.Docente.FindDocenteById)]
        public async Task<ActionResult<ResponseBase>> GetDocenteById(long id)
        {
            try
            {
                var query = new GetDocenteByIdQuery();
                query.IdDocente = id;
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }

        }

        [HttpGet(ApiRoutes.Docente.FindDocentesPaginated)]
        public async Task<ActionResult<ResponseBase>> GetDocentesPaginated([FromQuery] GetDocentesPaginatedRequest getDocentesPaginatedRequest)
        {
            try
            {
                var query = _mapper.Map<GetDocentesPaginatedQuery>(getDocentesPaginatedRequest);
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }

        }


        [HttpGet(ApiRoutes.Docente.FindDocentesByEscuela)]
        public async Task<ActionResult<ResponseBase>> GetDocentesByEscuela(int idEscuela)
        {
            try
            {
                var query = new GetDocentesByEscuelaQuery();
                query.IdEscuela = idEscuela;
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }

        }

        [HttpGet(ApiRoutes.Docente.FindDocentesByFacultad)]
        public async Task<ActionResult<ResponseBase>> GetDocentesByFacultad(int idFacultad)
        {
            try
            {
                var query = new GetDocentesByFacultadQuery();
                query.IdFacultad = idFacultad;
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }

        }

        [HttpPost(ApiRoutes.Docente.CreateDocente)]
        public async Task<ActionResult<ResponseBase>> CreateDocente([FromBody] CreateDocenteRequest createDocenteRequest)
        {
            try
            {
                var command = _mapper.Map<CreateDocenteCommand>(createDocenteRequest);
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }

        }

        [HttpPut(ApiRoutes.Docente.UpdateDocente)]
        public async Task<ActionResult<ResponseBase>> UpdateDocente([FromBody] UpdateDocenteRequest updateDocenteRequest)
        {
            try
            {
                var command = _mapper.Map<UpdateDocenteCommand>(updateDocenteRequest);
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }

        }

        [HttpDelete(ApiRoutes.Docente.DeleteDocente)]
        public async Task<ActionResult<ResponseBase>> DeleteDocente([FromBody] DeleteDocenteRequest deleteDocenteRequest)
        {
            try
            {
                var command = _mapper.Map<DeleteDocenteCommand>(deleteDocenteRequest);
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
