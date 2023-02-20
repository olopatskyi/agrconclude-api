using agrconclude.api.DTOs.Response;
using ExceptionHandler;
using agrconclude.core.Exceptions;

namespace agrconclude.api.ExceptionHandlers;

public class AppExceptionHandler : IExceptionHandler<AppException>
{
    public async Task ProceedAsync(HttpContext context, AppException exception)
    {
        var errors = exception.ErrorMessages;
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 400;
      
        await context.Response.WriteAsJsonAsync(exception.ErrorMessages);
    }
}