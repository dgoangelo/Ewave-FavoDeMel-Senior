using System;
using FavoDeMel.Domain.Commands.Produto;
using FluentValidation;

namespace FavoDeMel.Domain.Validations.Produto
{
    public abstract class ProdutoValidation<T> : AbstractValidator<T> where T : ProdutoCommand
    {
        protected void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .Length(2, 255);
        }

        protected void ValidarId()
        {
            RuleFor(c => c.IDProduto)
                .NotEqual(Guid.Empty);
        }

        protected void ValidarValor()
        {
            RuleFor(c => c.Valor)
                .GreaterThan(0);
        }
    }
}