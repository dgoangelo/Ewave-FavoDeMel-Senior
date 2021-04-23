using System;
using System.Threading;
using System.Threading.Tasks;
using FavoDeMel.Domain.Commands.PedidoProduto;
using FavoDeMel.Domain.Core.Notifications;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Domain.Services;
using MediatR;

namespace FavoDeMel.Domain.CommandHandlers
{
    public class PedidoProdutoCommandHandler : CommandHandler,
        IRequestHandler<AdicionarPedidoProdutoCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoProdutoRepository _pedidoProdutoRepository;


        public PedidoProdutoCommandHandler(
            IMediator mediator,
            IGeradorGuidService geradorGuidService,
            IPedidoRepository pedidoRepository,
            IPedidoProdutoRepository pedidoProdutoRepository,
            IProdutoRepository produtoRepository) : base(mediator, geradorGuidService)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoProdutoRepository = pedidoProdutoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Handle(AdicionarPedidoProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    ValidationErrors(request);
                    return await Task.FromResult(false);
                }

                var pedido = _pedidoRepository.GetById(request.IDPedido);
                var produto = _produtoRepository.GetById(request.IDProduto);

                var pedidoProduto = new PedidoProduto
                {
                    Id = GeradorGuidService.GetNexGuid(),
                    IDPedido = pedido.Id,
                    Pedido = pedido,
                    Produto = produto,
                    IDProduto = produto.Id,
                    Quantidade = request.Quantidade
                };

                pedidoProduto.CalcularValorTotal();

                _pedidoProdutoRepository.Add(pedidoProduto);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                await Mediator.Publish(new DomainNotification(request.MessageType, $"Erro: {ex.Message}"), cancellationToken);
                return await Task.FromResult(false);
            }
        }


    }
}