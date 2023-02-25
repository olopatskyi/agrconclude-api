using System.Reflection;
using agrconclude.API.Extensions;
using agrconclude.API.Middlewares;
using agrconclude.Application;
using ExceptionHandler;
using Serilog;

namespace agrconclude.API;

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

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}