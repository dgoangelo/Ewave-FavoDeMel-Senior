using System;
using FavoDeMel.Domain.Validations.Pedido;
using MediatR;

namespace FavoDeMel.Domain.Commands.Pedido
{
    public class CriarPedidoCommand : PedidoCommand, IRequest<Guid>
    {
        public override bool IsValid()
        {
            ValidationResult = new CriarPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}