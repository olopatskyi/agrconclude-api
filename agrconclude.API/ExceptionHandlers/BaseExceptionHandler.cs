
using agrconclude.API.DTOs.Response;
using Microsoft.AspNetCore.Http;

namespace ExceptionHandler;

public class BaseExceptionHandler : IExceptionHandler<Exception>
{
    public async Task ProceedAsync(HttpContext context, Exception exception)
    {
        var response = string.Empty;
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(ErrorResponse.Create(exception.Message));
    }
}