using FavoDeMel.Domain.Validations.Pedido;
using MediatR;

namespace FavoDeMel.Domain.Commands.Pedido
{
    public class AlterarStatusPedidoCommand : PedidoCommand, IRequest<bool>
    {
        public override bool IsValid()
        {
            ValidationResult = new AlterarStatusPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}