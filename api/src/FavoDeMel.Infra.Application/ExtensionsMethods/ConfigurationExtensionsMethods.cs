using System;
using FavoDeMel.Domain.Models.Settings;
using Microsoft.Extensions.Configuration;

namespace FavoDeMel.Infra.Application.ExtensionsMethods
{
    public static class ConfigurationExtensionsMethods
    {
        public static AppSettings GetAppSettings(this IConfiguration configuration)
        {
            var settings = new AppSettings
            {
                Data = new DataSettings(configuration),
                Swagger = new SwaggerSettings()
                {
                    Title = configuration[AppSettings.Keys.Swagger.TITLE],
                    Description = configuration[AppSettings.Keys.Swagger.DESCRIPTION],
                    Version = configuration[AppSettings.Keys.Swagger.VERSION]
                },
                RabbitMq = new RabbitMqSettings(configuration)
            };

            Console.WriteLine(settings.ToString());

            return settings;
        }
    }
}