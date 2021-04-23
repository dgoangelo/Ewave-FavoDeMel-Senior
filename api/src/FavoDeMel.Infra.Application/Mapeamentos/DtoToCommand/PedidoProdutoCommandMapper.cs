using AutoMapper;
using FavoDeMel.Domain.Commands.Pedido;
using FavoDeMel.Domain.Commands.PedidoProduto;
using FavoDeMel.Domain.Entities.Dto;
using FavoDeMel.Domain.Models;

namespace FavoDeMel.Infra.Application.Mapeamentos.DtoToCommand
{
    public class PedidoProdutoCommandMapper : AutoMapperBase
    {
        public PedidoProdutoCommandMapper(IMapperConfigurationExpression cfg) : base(cfg)
        {
        }

        public override void CreateMap()
        {
            MapperConfiguration.CreateMap<PedidoProdutoDto, AdicionarPedidoProdutoCommand>()
                .ConvertUsing(c => new AdicionarPedidoProdutoCommand
                {
                    IDPedido = c.IDPedido,
                    IDProduto = c.IDProduto,
                    IDPedidoProduto = c.IDProduto,
                    Quantidade = c.Quantidade
                });

            MapperConfiguration.CreateMap<PedidoProdutoViewModel, PedidoProdutoDto>()
                .ConvertUsing(c => new PedidoProdutoDto
                {
                    IDPedido = c.IDPedido,
                    IDProduto = c.IDProduto,
                    Quantidade = c.Quantidade
                });
        }
    }
}