using AutoMapper;
using FavoDeMel.Domain.Commands.Produto;
using FavoDeMel.Domain.Entities.Dto;

namespace FavoDeMel.Infra.Application.Mapeamentos.DtoToCommand
{
    public class ProdutoCommandMapper : AutoMapperBase
    {
        public ProdutoCommandMapper(IMapperConfigurationExpression cfg) : base(cfg)
        {
        }

        public override void CreateMap()
        {
            MapperConfiguration.CreateMap<ProdutoDto, CriarProdutoCommand>()
                .ConvertUsing(c => new CriarProdutoCommand
                {
                    IDProduto = c.IDProduto,
                    Nome = c.Nome,
                    Valor = c.Valor
                });
            
            MapperConfiguration.CreateMap<ProdutoDto, AtualizarProdutoCommand>()
                .ConvertUsing(c => new AtualizarProdutoCommand
                {
                    IDProduto = c.IDProduto,
                    Nome = c.Nome,
                    Valor = c.Valor
                });
        }
    }
}