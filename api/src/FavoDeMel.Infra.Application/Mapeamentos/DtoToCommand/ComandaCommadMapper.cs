using AutoMapper;
using FavoDeMel.Domain.Commands.Comanda;
using FavoDeMel.Domain.Entities.Dto;
using FavoDeMel.Domain.Models;

namespace FavoDeMel.Infra.Application.Mapeamentos.DtoToCommand
{
    public class ComandaCommadMapper : AutoMapperBase
    {
        public ComandaCommadMapper(IMapperConfigurationExpression cfg) : base(cfg)
        {
        }

        public override void CreateMap()
        {
            MapperConfiguration.CreateMap<ComandaDto, CriarComandaCommand>()
                .ConvertUsing(s => new CriarComandaCommand
                {
                   DataCriacao = s.DataCriacao,
                   IDComanda = s.IDComanda,
                   Mesa = s.Mesa,
                   Status = s.Status
                });
            MapperConfiguration.CreateMap<CriarComandaCommand, ComandaDto>()
                .ConvertUsing(s => new ComandaDto
                {
                    DataCriacao = s.DataCriacao,
                    IDComanda = s.IDComanda,
                    Mesa = s.Mesa,
                    Status = s.Status
                });

            MapperConfiguration.CreateMap<ComandaViewModel, ComandaDto>()
                .ConvertUsing(s => new ComandaDto{
                    DataCriacao = s.DataCriacao,
                    Mesa = s.Mesa,
                    Status = s.Status,
                    IDComanda = s.IDComanda
                });
        }
    }
}