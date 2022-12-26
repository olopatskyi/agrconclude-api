using agrconclude.core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace agrconclude.services;

public static class ServiceCollectionExtensions
{
    public static void ConstructServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
    } 
}