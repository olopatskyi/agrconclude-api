using agrconclude.api.DTOs.Response;
using agrconclude.api.Middlewares;
using agrconclude.core.Entities;
using agrconclude.core.Interfaces;
using agrconclude.core.Settings;
using agrconclude.dal.Context;
using agrconclude.services;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using agrconclude.api.Extensions;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        //Configure database
        builder.Services.AddDbContext<AppDbContext>(option =>
        {
            var server = builder.Configuration["SERVER_NAME"] ?? "localhost";
            var port = builder.Configuration["PORT"] ?? "5432";
            var database = builder.Configuration["DATABASE_NAME"] ?? "agrconclude";
            var username = builder.Configuration["USERNAME"] ?? "postgres";
            var password = builder.Configuration["PASSWORD"] ?? "password";
            var connectionString =
            @$"Host={server};
               Port={port};
               Database={database};
               Username={username};
               Password={password};";
            option.UseNpgsql(connectionString);
        });

        //Configure automapper
        builder.Services.AddSingleton(provider =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(Program).Assembly);
                cfg.ConstructServicesUsing(type => ActivatorUtilities.CreateInstance(provider, type));
            });

            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        });

        //Configure validation
        builder.Services.AddFluentValidationAutoValidation();

        builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = new InvalidModelStateResponse(context).Errors;
                    return new BadRequestObjectResult(errors);
                };
            });

        //Configure identity
        builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(opt =>
        {
            opt.Password.RequireDigit = true;
            opt.Password.RequireLowercase = true;
            opt.Password.RequireUppercase = true;
            opt.Password.RequireNonAlphanumeric = true;
            opt.Password.RequiredLength = 8;

            opt.User.RequireUniqueEmail = true;

            opt.SignIn.RequireConfirmedEmail = true;

            opt.SignIn.RequireConfirmedPhoneNumber = true;
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        //Configure authentication
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(option =>
    {
        var authSettings = builder.Configuration.GetSection(AuthSettings.SectionName).Get<AuthSettings>();
        option.RequireHttpsMetadata = false;
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = authSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = authSettings.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Key)),
            ValidateLifetime = false
        };
    });

        builder.Services.AddAuthorization();

        //Configure services
        builder.Services.AddTransient<IAuthService, AuthService>();

        //Configure settings
        builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection(AuthSettings.SectionName));
        builder.Services.AddSingleton<IAuthSettings>(x => x.GetRequiredService<IOptions<AuthSettings>>().Value);

        builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AnyOrigin", optionsBuilder =>
            {
                optionsBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod();
            });
        });
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        var app = builder.Build();

        app.UseCors("AnyOrigin");
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.UseAuthorization();

        app.MapControllers();
        
        app.InitializeDatabase();
        
        app.Run();
    }
}