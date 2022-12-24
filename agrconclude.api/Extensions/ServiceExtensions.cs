using agrconclude.dal.Context;
using Microsoft.EntityFrameworkCore;

namespace agrconclude.api.Extensions;

public static class ServiceExtensions
{
    public static void InitializeDatabase(this IApplicationBuilder builder)
    {
        var scope = builder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
    }
}