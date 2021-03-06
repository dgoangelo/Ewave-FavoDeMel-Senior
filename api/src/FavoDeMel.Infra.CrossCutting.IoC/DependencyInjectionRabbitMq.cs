using System;
using FavoDeMel.Domain.Models.Settings;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace FavoDeMel.Infra.CrossCutting.IoC
{
    public static class DependencyInjectionRabbitMq
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddMassTransit(bus =>
            {
                bus.UsingRabbitMq((context, config) =>
                {
                    config.Host(appSettings.RabbitMq.Url);
                });
            });

            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
            
            services.AddMassTransitHostedService();

            return services;
        }
    }
}