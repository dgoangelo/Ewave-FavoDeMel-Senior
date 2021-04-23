using System;
using System.Threading;
using System.Threading.Tasks;
using FavoDeMel.Domain.Commands.Comanda;
using FavoDeMel.Domain.Core.Notifications;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Entities.Enums;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Domain.Services;
using MediatR;

namespace FavoDeMel.Domain.CommandHandlers
{
    public class ComandaCommandHandler : CommandHandler,
        IRequestHandler<CriarComandaCommand, Guid>,
        IRequestHandler<AtualizarComandaCommand, bool>
    {
        private readonly IComandaRepository _comandaRepository;

        public ComandaCommandHandler(
            IMediator mediator,
            IGeradorGuidService geradorGuidService, 
            IComandaRepository comandaRepository) : base(mediator, geradorGuidService)
        {
            _comandaRepository = comandaRepository;
        }

        public async Task<Guid> Handle(CriarComandaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    ValidationErrors(request);
                    return await Task.FromResult(Guid.Empty);
                }

                var comanda = new Comanda
                {
                    DataCriacao = DateTime.Now,
                    Mesa = request.Mesa,
                    Status = Status.Pendente,
                    Id = GeradorGuidService.GetNexGuid()
                };

                _comandaRepository.Add(comanda);

                return await Task.FromResult(comanda.Id);
            }
            catch (Exception ex)
            {
                await Mediator.Publish(new DomainNotification(request.MessageType, $"Erro: {ex.Message}"), cancellationToken);
                return await Task.FromResult(Guid.Empty);
            }
        }

        public async Task<bool> Handle(AtualizarComandaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    ValidationErrors(request);
                    return await Task.FromResult(false);
                }

                var comanda = new Comanda
                {
                    DataCriacao = request.DataCriacao,
                    Mesa = request.Mesa,
                    Status = request.Status,
                    Id = request.IDComanda
                };

                _comandaRepository.Update(comanda);

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