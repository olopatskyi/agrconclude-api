using System.Reflection;
using System.Text;
using agrconclude.Domain.Entities;
using agrconclude.Domain.Settings;
using agrconclude.Infrastructure.Data;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Core;
using ILogger = Serilog.ILogger;

namespace agrconclude.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration?["JwtConfig:Key"]
                    ?? throw new InvalidOperationException("Missing JWT secret key configuration")))
            };
        });
    }

    public static void AddIdentity(this IServiceCollection services)
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
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }

    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string host = configuration.GetValue<string>("DatabaseSettings:Host") ?? "localhost";
        string port = configuration.GetValue<string>("DatabaseSettings:Port") ?? "5432";
        string database = configuration.GetValue<string>("DatabaseSettings:Database") ?? "agrconclude";
        string username = configuration.GetValue<string>("DatabaseSettings:Username") ?? "postgres";
        string password = configuration.GetValue<string>("DatabaseSettings:Password") ?? "password";

        string connectionString =
             $@"Host={host};
                Port={port};
                Database={database};
                Username={username};
                Password={password}";

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));
    }

    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddSingleton(provider =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
                cfg.ConstructServicesUsing(type => ActivatorUtilities.CreateInstance(provider, type));
            });

            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        });
    }

    public static void AddValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<Program>();
    }

    public static void InitializeSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Version = "V1",
                Title = "agrconclude.API",
                Description = "API for agrconclude"
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Description = "Please put jwt token here",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    Array.Empty<string>()
                }
            });
        });
    }

    public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("JwtConfig"));
        services.AddScoped<IJwtOptions>(provider => provider.GetRequiredService<IOptions<JwtOptions>>().Value);
    }
}