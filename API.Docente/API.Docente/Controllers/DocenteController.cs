﻿using API.Docentes.Application.Features.Docentes.Queries.GetDocenteById;
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
        public async Task<ActionResult<ResponseBase>> GetDocentesPaginated([FromQuery] GetDocentesPaginatedQuery query)
        {
            try
            {
                //var query = _mapper.Map<GetDocentesPaginatedQuery>(getDocentesPaginatedRequest);
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", ex.Message);
                return ResponseUtil.BadRequest(ex.Message.ToString());
            }

        }
    }
}
