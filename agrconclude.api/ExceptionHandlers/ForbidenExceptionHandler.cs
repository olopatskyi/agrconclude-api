using agrconclude.api.DTOs.Response;
using agrconclude.core.Exceptions;
using ExceptionHandler;

namespace agrconclude.api.ExceptionHandlers;

public class ForbidenExceptionHandler : IExceptionHandler<ForbiddenException>
{
    public async Task ProceedAsync(HttpContext context, ForbiddenException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 403;
        await context.Response.WriteAsJsonAsync(ErrorResponse.Create(exception.Message));
    }
}