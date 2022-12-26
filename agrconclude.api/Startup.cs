using agrconclude.core;
using agrconclude.core.Settings;
using agrconclude.dal;
using agrconclude.services;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;

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
        //Configure database connection
        services.CreateDatabaseConnection(connection: () => new DbConnectionSettings()
        {
            Server = "localhost",
            Port = "5432",
            Database = "agrconclude",
            UserID = "postgres",
            Password = "password"
        });

        
        //Register settings
        services.ConfigureSettings(Configuration);
        
        //Register services
        services.ConstructServices();

        //Add identity support
        services.AddIdentitySupport();

        //Add FluentValidation
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<Program>();

        //Add AutoMapper
        services.AddSingleton(provider =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(Program).Assembly);
                cfg.ConstructServicesUsing(type => ActivatorUtilities.CreateInstance(provider, type));
            });

            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        });
        
        
        //Configure Swagger
        services.InitializeSwagger();
        
        //Configure endpoints
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddControllers();
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

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}