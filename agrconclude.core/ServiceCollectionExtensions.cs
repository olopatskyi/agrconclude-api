using agrconclude.core.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace agrconclude.core;

public static class ServiceCollectionExtensions
{
    public static void ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthSettings>(settings => configuration.GetSection(AuthSettings.SectionName));
        services.AddSingleton<IAuthSettings>(provider => provider.GetRequiredService<IOptions<AuthSettings>>().Value);
    }
}