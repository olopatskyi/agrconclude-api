using agrconclude.API.DTOs.Response;
using agrconclude.Domain.Exceptions;
using ExceptionHandler;

namespace agrconclude.API.ExceptionHandlers;

public class ForbidenExceptionHandler : IExceptionHandler<ForbiddenException>
{
    public async Task ProceedAsync(HttpContext context, ForbiddenException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 403;
        await context.Response.WriteAsJsonAsync(ErrorResponse.Create(exception.Message));
    }
}