using System.Reflection;
using agrconclude.api.Middlewares;
using agrconclude.core;
using agrconclude.core.Settings;
using agrconclude.dal;
using agrconclude.services;
using AutoMapper;
using ExceptionHandler;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;

namespace agrconclude.api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        //Configure endpoints
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddControllers();

        services.AddDatabase(Configuration);

        services.AddIdentity();

        services.AddJwtAuthentication(Configuration);

        services.AddOptions(Configuration);

        services.AddServices();

        services.AddAutoMapper();

        services.AddValidation();
        
        services.AddExceptionHandlers(Assembly.GetAssembly(typeof(Program)) ?? Assembly.GetExecutingAssembly());

        //Configure Swagger
        services.InitializeSwagger();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseCors(builder =>
        {
            builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<ExceptionHandlerMiddleware>();
        
        app.UseSerilogRequestLogging(options =>
        {
            options.MessageTemplate = "Handled {RequestPath}";
            options.GetLevel = (httpContext, elapsed, ex) =>
            {
                if (ex != null || httpContext.Response.StatusCode > 499)
                {
                    return LogEventLevel.Error;
                }
                else if (httpContext.Response.StatusCode > 399)
                {
                    return LogEventLevel.Warning;
                }
                else
                {
                    return LogEventLevel.Information;
                }
            };
        });

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}