using NotificationAPI.Domain.Helpers;
using NotificationAPI.Infrastructure;
using NotificationAPI.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>() ?? new AppSettings();
        services.RegisterApplicationExternalDependencies(appSettings);

        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();