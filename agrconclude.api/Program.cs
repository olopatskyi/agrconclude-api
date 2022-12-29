using agrconclude.api;
using agrconclude.dal;
using agrconclude.dal.Context;

internal class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args)
            .Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<Program>>();
            try
            {
                logger.LogInformation("Trying to migrate database...");
                var context = services.GetRequiredService<AppDbContext>();
                DbSeeder.Seed(context);
                logger.LogInformation("Database successfully migrated");
            }
            catch (Exception exception)
            {
                logger.LogInformation($"An error occured while migrating the database. \n {exception.Message}");
            }
        }
        
        host.Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder => { builder.UseStartup<Startup>(); });

        return host;
    }
}