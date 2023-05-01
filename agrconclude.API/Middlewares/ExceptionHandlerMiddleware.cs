using AutoMapper;
using System.Reflection;
using ExceptionHandler;

namespace agrconclude.API.Middlewares
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

                var handler = context.RequestServices.GetService(handlerType);
                if (handler == null)
                {
                    handlerType = typeof(IExceptionHandler<>).MakeGenericType(typeof(Exception));
                    handler = context.RequestServices.GetRequiredService(typeof(IExceptionHandler<Exception>));
                }

                MethodInfo proceedAsyncMethod =
                    handler.GetType().GetMethod(nameof(IExceptionHandler<object>.ProceedAsync))
                    ?? throw new InvalidOperationException(
                        $"Method {nameof(IExceptionHandler<object>.ProceedAsync)} not found.");

                Task handleExceptionTask =
                    (Task)proceedAsyncMethod.Invoke(handler, new object[] { context, exception })!;

                await handleExceptionTask.ConfigureAwait(false);
            }
        }
    }
}