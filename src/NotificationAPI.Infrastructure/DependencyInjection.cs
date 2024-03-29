﻿using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationAPI.Domain.Helpers;
using NotificationAPI.Domain.Interfaces;
using NotificationAPI.Infrastructure.EntityFramework.Context;
using NotificationAPI.Infrastructure.Persistence;
using NotificationAPI.Infrastructure.Producer;

namespace NotificationAPI.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection RegisterApplicationExternalDependencies(this IServiceCollection services, AppSettings appSettings, IConfiguration configuration)
    {
        services.AddScoped<INotificationProducer, NotificationProducer>();
        ConfigureMassTransit(appSettings, services);

        return services;
    }

    private static void ConfigureMassTransit(AppSettings appSettings, IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(appSettings.MassTransit.Servidor, "/", h =>
                {
                    h.Username(appSettings.MassTransit.Usuario);
                    h.Password(appSettings.MassTransit.Senha);
                });

                cfg.ConfigureEndpoints(context);
            });
        });
    }
}