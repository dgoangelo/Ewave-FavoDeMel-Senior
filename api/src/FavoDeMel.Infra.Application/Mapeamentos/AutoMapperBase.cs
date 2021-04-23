using AutoMapper;

namespace FavoDeMel.Infra.Application.Mapeamentos
{
    public abstract class AutoMapperBase
    {
        /// <summary>
        /// IMapperConfigurationExpression
        /// </summary>
        public IMapperConfigurationExpression MapperConfiguration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cfg"></param>
        protected AutoMapperBase(IMapperConfigurationExpression cfg)
        {
            MapperConfiguration = cfg;
        }

        /// <summary>
        /// CreateMap
        /// </summary>
        public abstract void CreateMap();
    }
}