using Microsoft.AspNetCore.Http;

namespace ExceptionHandler;

public interface IExceptionHandler<in TException>
{
    Task ProceedAsync(HttpContext context, TException exception);
}