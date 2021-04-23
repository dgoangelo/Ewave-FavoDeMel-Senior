using System.Collections.Generic;
using AutoMapper;
using FavoDeMel.Domain.Commands.Pedido;
using FavoDeMel.Domain.Commands.PedidoProduto;
using FavoDeMel.Domain.Entities.Dto;
using FavoDeMel.Domain.Models;
using FavoDeMel.Infra.Application.ExtensionsMethods;

namespace FavoDeMel.Infra.Application.Mapeamentos.DtoToCommand
{
    public class PedidoCommandMapper : AutoMapperBase
    {
        public PedidoCommandMapper(IMapperConfigurationExpression cfg) : base(cfg)
        {
        }

        public override void CreateMap()
        {
            MapperConfiguration.CreateMap<PedidoDto, CriarPedidoCommand>()
                .ConvertUsing(c => new CriarPedidoCommand
                {
                    DataPedido = c.DataPedido,
                    IDComanda = c.IDComanda,
                    IDGarcom = c.IDGarcom,
                    IDPedido = c.IDPedido,
                    Situacao = c.SituacaoPedido,
                    Produtos = c.Produtos == null || c.Produtos.Count == 0 ? new List<AdicionarPedidoProdutoCommand>() : c.Produtos.MapModelAndDto<List<AdicionarPedidoProdutoCommand>>()
                });

            MapperConfiguration.CreateMap<PedidoDto, AlterarStatusPedidoCommand>()
                .ConvertUsing(c => new AlterarStatusPedidoCommand
                {
                    IDPedido = c.IDPedido,
                    Situacao = c.SituacaoPedido
                });

            MapperConfiguration.CreateMap<PedidoViewModel, PedidoDto>()
                .ConvertUsing(c => new PedidoDto
                {
                    IDComanda = c.IDComanda,
                    IDGarcom = c.IDGarcom,
                    IDPedido = c.IDPedido,
                    SituacaoPedido = c.SituacaoPedido,
                    DataPedido = c.DataPedido,
                    Produtos = c.Produtos == null || c.Produtos.Count == 0 ? new List<PedidoProdutoDto>() : c.Produtos.MapModelAndDto<List<PedidoProdutoDto>>()
                });
        }
    }
}