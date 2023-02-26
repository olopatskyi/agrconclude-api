using agrconclude.Application.Interfaces;
using agrconclude.Application.Services;
using agrconclude.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace agrconclude.Application;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IUserService, UserService>();
    }
}