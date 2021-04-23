using FavoDeMel.Domain.Core.Commands;
using FavoDeMel.Domain.Core.Notifications;
using FavoDeMel.Domain.Services;
using MediatR;

namespace FavoDeMel.Domain.CommandHandlers
{
    public class CommandHandler
    {
        public readonly IMediator Mediator;
        public readonly IGeradorGuidService GeradorGuidService;

        public CommandHandler(IMediator mediator, IGeradorGuidService geradorGuidService)
        {
            Mediator = mediator;
            GeradorGuidService = geradorGuidService;
        }

        protected void ValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                Mediator.Publish(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }
    }
}