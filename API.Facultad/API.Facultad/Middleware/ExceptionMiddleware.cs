using Api.Facultad.Application.Exceptions;
using Api.Facultad.Application.Utils;
using Newtonsoft.Json;
using System.Net;


namespace CleanArchitecture.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                var statusCode = HttpStatusCode.InternalServerError;
                var result = string.Empty;

                switch(ex)
                {
                    case NotFoundException notFoundException:
                        statusCode = HttpStatusCode.NotFound;
                        break;
                    case ValidationException validationException:
                        statusCode = HttpStatusCode.BadRequest;
                        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = JsonConvert.SerializeObject(ResponseUtil.CustomResponse(statusCode, ex.StackTrace, ex.Message));
                        break;
                    case BadRequestException badRequestException:
                        statusCode = HttpStatusCode.BadRequest;
                        break;
                    default:
                        break;
                }

                if(string.IsNullOrEmpty(result))
                {
                    result = JsonConvert.SerializeObject(ResponseUtil.CustomResponse(statusCode,  ex.StackTrace, ex.Message));
                }

                context.Response.StatusCode = (int)statusCode;   

                await context.Response.WriteAsync(result);
            }
        }
    }
}
