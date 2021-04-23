using System;
using System.Collections.Generic;
using FavoDeMel.Domain.Core.Entities;
using FavoDeMel.Domain.Entities.Enums;

namespace FavoDeMel.Domain.Entities
{
    public class Pedido : Entity
    {
        public DateTime DataPedido { get; set; }
        public SituacaoPedido Situacao { get; set; }

        public Guid IDGarcom { get; set; }
        public virtual Garcom Garcom { get;  set; }

        public Guid IDComanda { get; set; }
        public virtual Comanda Comanda { get; set; }
        
        public virtual ICollection<PedidoProduto> PedidoProdutos { get; set; }
    }
}