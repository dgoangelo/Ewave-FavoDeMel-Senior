using AutoMapper;
using FavoDeMel.Infra.Application.ExtensionsMethods;
using FavoDeMel.Infra.Application.Mapeamentos.DtoToCommand;

namespace FavoDeMel.Infra.Application.Mapeamentos
{
    public static class AutoMapperConfiguration
    {
        private static IMapper _mapper;

        public static IMapper GetMapper()
        {
            if (_mapper != null)
                return _mapper;

            var config = new MapperConfiguration(mapperConfiguration =>
            {
                mapperConfiguration.CreateMap<ProdutoCommandMapper>();
                mapperConfiguration.CreateMap<GarcomCommandMapper>();
                mapperConfiguration.CreateMap<ComandaCommadMapper>();
                mapperConfiguration.CreateMap<PedidoCommandMapper>();
                mapperConfiguration.CreateMap<PedidoProdutoCommandMapper>();

            });

            config.AssertConfigurationIsValid();
            _mapper = config.CreateMapper();

            return _mapper;
        }
    }
}