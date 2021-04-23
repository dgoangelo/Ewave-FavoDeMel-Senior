using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FavoDeMel.Domain.Commands.Pedido;
using FavoDeMel.Domain.Core.Notifications;
using FavoDeMel.Domain.Core.RabbitMQ;
using FavoDeMel.Domain.Core.RabbitMQ.Pedido;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Entities.Enums;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Domain.Services;
using MediatR;

namespace FavoDeMel.Domain.CommandHandlers
{
    public class PedidoCommandHandler : CommandHandler,
        IRequestHandler<CriarPedidoCommand, Guid>,
        IRequestHandler<AlterarStatusPedidoCommand, bool>
    {
        private readonly IGarcomRepository _garcomRepository;
        private readonly IComandaRepository _comandaRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IRabbiqMqService _rabbiqMqService;

        public PedidoCommandHandler(IMediator mediator,
            IGeradorGuidService geradorGuidService, IGarcomRepository garcomRepository,
            IComandaRepository comandaRepository, IPedidoRepository pedidoRepository,
            IProdutoRepository produtoRepository, IRabbiqMqService rabbiqMqService) : base(mediator, geradorGuidService)
        {
            _garcomRepository = garcomRepository;
            _comandaRepository = comandaRepository;
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _rabbiqMqService = rabbiqMqService;
        }

        public async Task<Guid> Handle(CriarPedidoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    ValidationErrors(request);
                    return await Task.FromResult(Guid.Empty);
                }

                var comanda = _comandaRepository.GetById(request.IDComanda);
                var garcom = _garcomRepository.GetById(request.IDGarcom);

                var pedido = new Pedido
                {
                    Id = GeradorGuidService.GetNexGuid(),
                    DataPedido = DateTime.Now,
                    IDComanda = comanda.Id,
                    Comanda = comanda,
                    IDGarcom = garcom.Id,
                    Garcom = garcom,
                    Situacao = SituacaoPedido.Aberto,
                    PedidoProdutos = new List<PedidoProduto>()
                };

                request.Produtos.ForEach(c =>
                {
                    var pedidoProduto = new PedidoProduto
                    {
                        Id = GeradorGuidService.GetNexGuid(),
                        Produto = _produtoRepository.GetById(c.IDProduto),
                        IDProduto = c.IDProduto,
                        Quantidade = c.Quantidade,
                        IDPedido = c.IDPedido,
                    };

                    pedidoProduto.CalcularValorTotal();

                    pedido.PedidoProdutos.Add(pedidoProduto);
                });

                _pedidoRepository.Add(pedido);

                return await Task.FromResult(pedido.Id);

            }
            catch (Exception ex)
            {
                await Mediator.Publish(new DomainNotification(request.MessageType, $"Erro: {ex.Message}"), cancellationToken);
                return await Task.FromResult(Guid.Empty);
            }
        }

        public async Task<bool> Handle(AlterarStatusPedidoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    ValidationErrors(request);
                    return await Task.FromResult(false);
                }

                var pedido = _pedidoRepository.GetById(request.IDPedido);
                pedido.Situacao = request.Situacao;

                if (pedido.Situacao == SituacaoPedido.Finalizado)
                {
                    pedido.Comanda.Status = Status.Encerrado;
                }

                _pedidoRepository.Update(pedido);

                var mensagem = new MensagemCozinhaPedido
                {
                    DataMensagem = DateTime.Now,
                    IDMensagem = GeradorGuidService.GetNexGuid(),
                    Mensagem = $"O pedido  da mesa {pedido.Comanda.Mesa} encontra-se na seguinte situação: {request.Situacao.ToString()} - Garçom resposavel: {pedido.Garcom.Nome}"
                };

                await _rabbiqMqService.Send(mensagem, new Uri(Queues.Pedido), cancellationToken);

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