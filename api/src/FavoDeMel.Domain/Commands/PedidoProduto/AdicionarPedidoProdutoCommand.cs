using FavoDeMel.Domain.Validations.PedidoProduto;
using MediatR;

namespace FavoDeMel.Domain.Commands.PedidoProduto
{
    public class AdicionarPedidoProdutoCommand : PedidoProdutoCommand, IRequest<bool>
    {
        public override bool IsValid()
        {
            ValidationResult = new AdicionarPedidoProdutoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}