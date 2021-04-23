using System;
using FavoDeMel.Domain.Commands.PedidoProduto;
using FluentValidation;

namespace FavoDeMel.Domain.Validations.PedidoProduto
{
    public abstract class PedidoProdutoValidation<T> : AbstractValidator<T> where T : PedidoProdutoCommand
    {
        protected void ValidarQuantidade()
        {
            RuleFor(c => c.Quantidade)
                .GreaterThan(0);
        }

        protected void ValidarIdPedido()
        {
            RuleFor(c => c.IDPedido)
                .NotEqual(Guid.Empty);
        }

        protected void ValidarIdProduto()
        {
            RuleFor(c => c.IDProduto)
                .NotEqual(Guid.Empty);
        }
    }
}