using FavoDeMel.Domain.Models.Settings;
using FavoDeMel.Infra.CrossCutting.IoC;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FavoDeMel.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            return DependencyInjectionServices.RegisterServices(services);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="appSettings"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterRepository(this IServiceCollection services, AppSettings appSettings)
        {
            return DependencyInjectionRepositorys.RegisterServices(services, appSettings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterCommandHandle(this IServiceCollection services)
        {
            return DependencyInjectionCommandHandle.RegisterServices(services);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterFinders(this IServiceCollection services)
        {
            return DependencyInjectionFinders.RegisterServices(services);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="appSettings"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterRabbitMq(this IServiceCollection services, AppSettings appSettings)
        {
            return DependencyInjectionRabbitMq.RegisterServices(services, appSettings);
        }
    }
}