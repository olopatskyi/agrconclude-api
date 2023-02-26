using System.Net;
using agrconclude.API;
using agrconclude.API.Extensions;
using Serilog;

internal class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration().Create();
        TryStartHost(() =>
        {
            CreateHostBuilder(args).Build()
                .MigrateDatabaseOnStart(
                    onSuccess: () => { Log.Logger.Information("Database migrated successfully."); },
                    onFailure: () => { Log.Logger.Error("An error occured while migrating database."); })
                .Run();
        });
    }

    private static void TryStartHost(Action action)
    {
        try
        {
            Log.Logger.Information("Starting host...");
            action();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
        }
        finally
        {
            Log.Information("Stopping host...");
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath);
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json",
                    optional: true, reloadOnChange: true);

                config.AddEnvironmentVariables();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseKestrel()
                    .UseStartup<Startup>()
                    .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.AddSerilog();
                    });
            })
            .UseSerilog((hostingContext, loggerConfiguration) =>
            {
                loggerConfiguration
                    .MinimumLevel.Information()
                    .Enrich.FromLogContext()
                    .WriteTo.Console();
            });
}