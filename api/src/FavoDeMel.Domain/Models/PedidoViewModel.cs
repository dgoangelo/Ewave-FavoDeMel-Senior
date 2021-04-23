using System;
using System.Collections.Generic;
using FavoDeMel.Domain.Entities.Enums;

namespace FavoDeMel.Domain.Models
{
    public class PedidoViewModel
    {
        public Guid IDPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public Guid IDGarcom { get; set; }
        public Guid IDComanda { get; set; }
        public SituacaoPedido SituacaoPedido { get; set; }

        public List<PedidoProdutoViewModel> Produtos { get; set; }

        public PedidoViewModel()
        {
            Produtos = new List<PedidoProdutoViewModel>();
        }
    }
}