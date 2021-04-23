using FavoDeMel.Domain.Core.Events;
using FluentValidation.Results;

namespace FavoDeMel.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}