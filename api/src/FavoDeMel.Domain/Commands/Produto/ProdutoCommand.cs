using System;
using FavoDeMel.Domain.Core.Commands;

namespace FavoDeMel.Domain.Commands.Produto
{
    public abstract class ProdutoCommand : Command
    {
        public Guid IDProduto { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}