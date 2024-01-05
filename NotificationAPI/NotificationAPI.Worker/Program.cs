using MassTransit;
using NotificationAPI.Domain.Helpers;
using NotificationAPI.Worker;
using NotificationAPI.Worker.Consumer;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>() ?? new AppSettings();
        services.AddSingleton(appSettings);


        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(appSettings.MassTransit.Servidor, "/", h =>
                {
                    h.Username(appSettings.MassTransit.Usuario);
                    h.Password(appSettings.MassTransit.Senha);
                });
                cfg.ReceiveEndpoint(appSettings.MassTransit.NomeFila, e =>
                {
                    e.Consumer<NotificationReader>(context);
                });
            });

            x.AddConsumer<NotificationReader>();
        });


        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();