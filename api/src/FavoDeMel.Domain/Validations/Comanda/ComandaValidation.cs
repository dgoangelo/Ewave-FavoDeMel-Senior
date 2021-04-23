using System;
using FavoDeMel.Domain.Commands.Comanda;
using FluentValidation;

namespace FavoDeMel.Domain.Validations.Comanda
{
    public abstract class ComandaValidation<T> : AbstractValidator<T> where T : ComandaCommand
    {
        protected void ValidarMesa()
        {
            RuleFor(c => c.Mesa)
                .GreaterThan(0);
        }

        protected void ValidarId()
        {
            RuleFor(c => c.IDComanda)
                .NotEqual(Guid.Empty);
        }
    }
}