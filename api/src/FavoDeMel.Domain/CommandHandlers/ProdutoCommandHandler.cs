using System;
using System.Threading;
using System.Threading.Tasks;
using FavoDeMel.Domain.Commands.Produto;
using FavoDeMel.Domain.Core.Notifications;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Domain.Services;
using MediatR;

namespace FavoDeMel.Domain.CommandHandlers
{
    public class ProdutoCommandHandler : CommandHandler,
        IRequestHandler<CriarProdutoCommand, Guid>,
        IRequestHandler<AtualizarProdutoCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;
       

        public ProdutoCommandHandler(
            IMediator mediator,
            IGeradorGuidService geradorGuidService,
            IProdutoRepository produtoRepository) : base(mediator, geradorGuidService)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Guid> Handle(CriarProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    ValidationErrors(request);
                    return await Task.FromResult(Guid.Empty);
                }

                var produto = new Produto
                {
                    Id = GeradorGuidService.GetNexGuid(),
                    Valor = request.Valor,
                    Nome = request.Nome
                };

                _produtoRepository.Add(produto);

                return await Task.FromResult(produto.Id);
            }
            catch (Exception ex)
            {
                await Mediator.Publish(new DomainNotification(request.MessageType, $"Erro: {ex.Message}"), cancellationToken);
                return await Task.FromResult(Guid.Empty);
            }
        }

        public async Task<bool> Handle(AtualizarProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    ValidationErrors(request);
                    return await Task.FromResult(false);
                }

                var produto = new Produto
                {
                    Id = request.IDProduto,
                    Valor = request.Valor,
                    Nome = request.Nome
                };

                _produtoRepository.Update(produto);

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