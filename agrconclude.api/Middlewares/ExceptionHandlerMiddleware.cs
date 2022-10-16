using agrconclude.api.DTOs.Response;
using agrconclude.core.Exceptions;
using AutoMapper;
using System.Net;
using System.Text.Json;

namespace agrconclude.api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMapper _mapper;

        public ExceptionHandlerMiddleware(RequestDelegate next, IMapper mapper)
        {
            _next = next;
            _mapper = mapper;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                var result = string.Empty;
                response.ContentType = "application/json";

                switch (exception)
                {
                    case AppException ex:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var appErrors = _mapper.Map<List<ErrorResponse>>(ex.ErrorMessages);
                        result = JsonSerializer.Serialize(appErrors);
                        break;
                    case KeyNotFoundException ex:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        result = JsonSerializer.Serialize(new { message = exception?.Message });
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        result = JsonSerializer.Serialize(new { message = exception?.Message });
                        break;
                }

                await response.WriteAsync(result);
            }
        }
    }
}
