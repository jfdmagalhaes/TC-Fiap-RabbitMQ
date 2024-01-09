using MassTransit;
using Microsoft.EntityFrameworkCore;
using NotificationAPI.Domain.Helpers;
using NotificationAPI.Domain.Interfaces;
using NotificationAPI.Infrastructure.EntityFramework.Context;
using NotificationAPI.Infrastructure.Persistence;
using NotificationAPI.Worker;
using NotificationAPI.Worker.Consumer;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>() ?? new AppSettings();

        services.AddSingleton(appSettings);
        services.AddDbContext<INotificationDbContext, NotificationDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); });
        services.AddTransient<INotificationRepository, NotificationRepository>();

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