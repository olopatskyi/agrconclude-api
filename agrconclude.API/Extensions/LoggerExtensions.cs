using Serilog;
using ILogger = Serilog.ILogger;

namespace agrconclude.API.Extensions;

public static class LoggerExtensions
{
    public static ILogger Create(this LoggerConfiguration configuration)
    {
        return new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
    }

}