using System;
using FavoDeMel.Domain.Core.Commands;

namespace FavoDeMel.Domain.Commands.PedidoProduto
{
    public abstract class PedidoProdutoCommand : Command
    {
        public Guid IDPedidoProduto { get; set; }
        public Guid IDPedido { get; set; }
        public Guid IDProduto { get; set; }
        public int Quantidade { get; set; }
    }
}