using System.Diagnostics;
using agrconclude.core.Entities;
using agrconclude.core.Settings;
using agrconclude.dal.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace agrconclude.dal;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection CreateDatabaseConnection(this IServiceCollection services,
        Func<DbConnectionSettings> connection)
    {
        Debug.WriteLine("Creating connection");
        services.AddDbContext<AppDbContext>(options =>
        {
            var dbSettings = connection.Invoke();
            var connectionString =
                @$"Host={dbSettings.Server};
               Port={dbSettings.Port};
               Database={dbSettings.Database};
               Username={dbSettings.UserID};
               Password={dbSettings.Password};";

            options.UseNpgsql(connectionString);
        });
        return services;
    }

    public static IServiceCollection AddIdentitySupport(this IServiceCollection services)
    {
        services.AddIdentityCore<AppUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = true;
            })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<AppDbContext>();
        
        return services;
    }
}