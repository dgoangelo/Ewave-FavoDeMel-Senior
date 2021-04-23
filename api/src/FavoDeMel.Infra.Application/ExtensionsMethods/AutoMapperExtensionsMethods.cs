using System;
using AutoMapper;
using FavoDeMel.Infra.Application.Mapeamentos;

namespace FavoDeMel.Infra.Application.ExtensionsMethods
{
    public static class AutoMapperExtensionsMethods
    {
        public static void CreateMap<T>(this IMapperConfigurationExpression cfg) where T : AutoMapperBase
        {
            var tipoAutoMapper = typeof(T);

            var magicMapper = Activator.CreateInstance(tipoAutoMapper, cfg) as T;

            magicMapper.CreateMap();
        }
    }
}