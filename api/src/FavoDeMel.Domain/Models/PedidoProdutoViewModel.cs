using System;

namespace FavoDeMel.Domain.Models
{
    public class PedidoProdutoViewModel
    {
        public Guid IDPedido { get; set; }
        public Guid IDProduto { get; set; }
        public int Quantidade { get; set; }
    }
}