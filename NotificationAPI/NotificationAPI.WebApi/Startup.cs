using NotificationAPI.Domain.Helpers;
using NotificationAPI.Infrastructure;

namespace NotificationAPI.WebApi;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>() ?? new AppSettings();
        services.AddSingleton(appSettings);
        services.RegisterApplicationExternalDependencies(appSettings);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseHttpsRedirection();
    }
}