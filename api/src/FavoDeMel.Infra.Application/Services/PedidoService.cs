using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Domain.Commands.Pedido;
using FavoDeMel.Domain.Commands.PedidoProduto;
using FavoDeMel.Domain.Entities.Dto;
using FavoDeMel.Domain.Services;
using FavoDeMel.Infra.Application.Interface.Finders;
using MediatR;

namespace FavoDeMel.Infra.Application.Services
{
    public class PedidoService : BaseServices, IPedidoService
    {
        private readonly IPedidoFinder _pedidoFinder;

        public PedidoService(IMediator mediator, IPedidoFinder pedidoFinder) : base(mediator)
        {
            _pedidoFinder = pedidoFinder;
        }

        public async Task<PedidoDto> Criar(PedidoDto dto)
        {
            var criarPedidoCommand = MapperModelAndDto.Map<CriarPedidoCommand>(dto);
            dto.IDPedido = await Mediator.Send(criarPedidoCommand);
            return dto;
        }

        public async Task<IEnumerable<PedidoDto>> ObterPedidos()
        {
            return await _pedidoFinder.ObterPedidos();
        }

        public async Task<PedidoDto> ObterPedido(Guid id)
        {
            return await _pedidoFinder.ObterPedido(id);
        }

        public async Task<bool> AdicionarProdutoPedido(PedidoProdutoDto dto)
        {
            var adicionarPedidoProdutoCommand = MapperModelAndDto.Map<AdicionarPedidoProdutoCommand>(dto);
            return await Mediator.Send(adicionarPedidoProdutoCommand);
        }
    }
}