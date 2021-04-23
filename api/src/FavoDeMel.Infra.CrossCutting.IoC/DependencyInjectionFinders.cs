using System;
using System.Collections.Generic;
using System.Linq;
using FavoDeMel.Infra.Application.Interface;
using FavoDeMel.Infra.Dapper.Abstractions;
using FavoDeMel.Infra.Dapper.Connection;
using Microsoft.Extensions.DependencyInjection;

namespace FavoDeMel.Infra.CrossCutting.IoC
{
    public static class DependencyInjectionFinders
    {

        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IFavoDeMelConnectionFactory, FavoDeMelConnectionFactory>();

            foreach (var item in GetClassName("Finder"))
            {
                foreach (var typeArray in item.Value)
                {
                    services.AddScoped(typeArray, item.Key);
                }
            }

            return services;
        }

        private static Dictionary<Type, Type[]> GetClassName(string assemblyName)
        {
            if (string.IsNullOrEmpty(assemblyName))
                return new Dictionary<Type, Type[]>();

            Type type = typeof(FinderSql);

            var assembly = type.Assembly;
            var ts = assembly.GetTypes().ToList();

            var result = new Dictionary<Type, Type[]>();

            foreach (var item in ts.Where(s => !s.IsInterface))
            {
                var isIsAssignable = type.IsAssignableFrom(item);

                if (isIsAssignable)
                {
                    var interfaceType = item.GetInterfaces();
                    result.Add(item, interfaceType);
                }
            }
            return result;
        }
    }
}
