using agrconclude.API;
using agrconclude.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace agrconclude.API.Extensions;

public static class HostExtensions
{
    public static IHost MigrateDatabaseOnStart(this IHost host, Action onSuccess, Action onFailure)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var database = services.GetRequiredService<AppDbContext>().Database;
        try
        {
            //database.Migrate();
            onSuccess();
        }
        catch (Exception)
        {
            onFailure();
        }

        return host;
    }
}