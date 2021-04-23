using System;
using FavoDeMel.Domain.Validations.Produto;
using MediatR;

namespace FavoDeMel.Domain.Commands.Produto
{
    public class CriarProdutoCommand : ProdutoCommand, IRequest<Guid>
    {
        public override bool IsValid()
        {
            ValidationResult = new CriarProdutoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}