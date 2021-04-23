using System;
using FavoDeMel.Domain.Core.Entities;

namespace FavoDeMel.Domain.Entities
{
    public class PedidoProduto : Entity
    {
        public Guid IDPedido { get; set; }
        public virtual Pedido Pedido { get; set; }

        public Guid IDProduto { get; set; }
        public virtual Produto Produto { get; set; }

        public int Quantidade { get; set; }
        public decimal ValorTotal { get; private set; }

        public decimal CalcularValorTotal()
        {
            return ValorTotal = Produto.Valor * Quantidade;
        }
    }
}