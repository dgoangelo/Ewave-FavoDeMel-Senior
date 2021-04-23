using System;
using FavoDeMel.Domain.Commands.Pedido;
using FluentValidation;

namespace FavoDeMel.Domain.Validations.Pedido
{
    public abstract class PedidoValidation<T> : AbstractValidator<T> where T : PedidoCommand
    {
        protected void ValidarIdGarcom()
        {
            RuleFor(c => c.IDGarcom)
                .NotEqual(Guid.Empty);
        }

        protected void ValidarIdComanda()
        {
            RuleFor(c => c.IDComanda)
                .NotEqual(Guid.Empty);
        }

        protected void ValidarId()
        {
            RuleFor(c => c.IDPedido)
                .NotEqual(Guid.Empty);
        }
    }
}