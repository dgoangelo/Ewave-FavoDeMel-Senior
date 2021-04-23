using System;
using FavoDeMel.Domain.Commands.Garcom;
using FavoDeMel.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FavoDeMel.Domain.Core.Notifications;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Services;
using FavoDeMel.Domain.ValueObjects;

namespace FavoDeMel.Domain.CommandHandlers
{
    public class GarcomCommandHandler : CommandHandler,
        IRequestHandler<CriarGarcomCommand, Guid>,
        IRequestHandler<AtualizarGarcomCommand, bool>
    {
        private readonly IGarcomRepository _garcomRepository;

        public GarcomCommandHandler(
            IMediator mediator,
            IGeradorGuidService geradorGuidService,
            IGarcomRepository garcomRepository) : base(mediator, geradorGuidService)
        {
            _garcomRepository = garcomRepository;
        }


        public async Task<Guid> Handle(CriarGarcomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(request.Cpf))
                {
                    request.Cpf = new Cpf(request.Cpf).ToString();
                }

                if (!request.IsValid())
                {
                    ValidationErrors(request);
                    return await Task.FromResult(Guid.Empty);
                }
                
                var garcom = new Garcom
                {
                    Id = GeradorGuidService.GetNexGuid(),
                    Cpf = request.Cpf,
                    Nome = request.Nome
                };

                _garcomRepository.Add(garcom);
                return await Task.FromResult(garcom.Id);
            }
            catch (Exception ex)
            {
                await Mediator.Publish(new DomainNotification(request.MessageType, $"Erro: {ex.Message}"), cancellationToken);
                return await Task.FromResult(Guid.Empty);
            }
        }

        public async Task<bool> Handle(AtualizarGarcomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(request.Cpf))
                {
                    request.Cpf = new Cpf(request.Cpf).ToString();
                }

                if (!request.IsValid())
                {
                    ValidationErrors(request);
                    return await Task.FromResult(false);
                }

                var garcom = new Garcom
                {
                    Id = request.IDGarcom,
                    Cpf = request.Cpf,
                    Nome = request.Nome
                };

                _garcomRepository.Update(garcom);

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