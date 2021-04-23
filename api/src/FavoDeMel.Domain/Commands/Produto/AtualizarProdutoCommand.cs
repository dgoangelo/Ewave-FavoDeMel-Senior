using FavoDeMel.Domain.Validations.Produto;
using MediatR;

namespace FavoDeMel.Domain.Commands.Produto
{
    public class AtualizarProdutoCommand : ProdutoCommand, IRequest<bool>
    {
        public override bool IsValid()
        {
            ValidationResult = new AtualizarProdutoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}