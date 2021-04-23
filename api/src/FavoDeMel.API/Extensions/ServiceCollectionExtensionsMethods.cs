using System.IO;
using System.Reflection;
using FavoDeMel.Domain.Models.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace FavoDeMel.API.Extensions
{
    public static class ServiceCollectionExtensionsMethods
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services, SwaggerSettings settings)
        {
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(Path.ChangeExtension(Assembly.GetAssembly(typeof(Startup)).Location, "xml"));
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = settings.Title,
                    Version = settings.Version,
                    Description = settings.Description,
                    Contact = new OpenApiContact()
                    {
                        Name = "Diego Angelo de Carvalho",
                        Email = "diego.carvalho@ewave.com.br"
                    }
                });
            });

            return services;
        }
    }
}