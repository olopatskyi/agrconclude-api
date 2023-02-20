using agrconclude.api.DTOs.Response;
using agrconclude.core.Exceptions;
using AutoMapper;
using System.Net;
using System.Reflection;
using System.Text.Json;
using ExceptionHandler;

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
                var handlerType = typeof(IExceptionHandler<>).MakeGenericType(exception.GetType());
                var handler = context.RequestServices.GetRequiredService(handlerType);

                var proceedAsyncMethod = handler.GetType().GetMethod(nameof(BaseExceptionHandler.ProceedAsync))
                                         ?? throw new InvalidOperationException();
                var handleExceptionTask =
                    (Task)proceedAsyncMethod.Invoke(handler, new object[] { context, exception })!;

                await handleExceptionTask.ConfigureAwait(false);
            }
        }
    }
}