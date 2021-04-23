using System;

namespace FavoDeMel.Domain.Entities.Dto
{
    public class PedidoProdutoDto
    {
        public Guid IDPedidoProduto { get; set; }
        public Guid IDPedido { get; set; }
        public Pedido Pedido { get; set; }

        public Guid IDProduto { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
    }
}