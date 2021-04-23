using AutoMapper;
using FavoDeMel.Domain.Commands.Garcom;
using FavoDeMel.Domain.Entities.Dto;

namespace FavoDeMel.Infra.Application.Mapeamentos.DtoToCommand
{
    public class GarcomCommandMapper : AutoMapperBase
    {
        public GarcomCommandMapper(IMapperConfigurationExpression cfg) : base(cfg)
        {
        }

        public override void CreateMap()
        {
            MapperConfiguration.CreateMap<GarcomDto, CriarGarcomCommand>()
                .ConvertUsing(c => new CriarGarcomCommand
                {
                    IDGarcom = c.IDGarcom,
                    Cpf = c.Cpf,
                    Nome = c.Nome
                });

            MapperConfiguration.CreateMap<GarcomDto, AtualizarGarcomCommand>()
                .ConvertUsing(c => new AtualizarGarcomCommand
                {
                    IDGarcom = c.IDGarcom,
                    Cpf = c.Cpf,
                    Nome = c.Nome
                });
        }
    }
}