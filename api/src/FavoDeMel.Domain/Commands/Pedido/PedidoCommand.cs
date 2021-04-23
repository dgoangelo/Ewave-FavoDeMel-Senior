using System;
using System.Collections.Generic;
using FavoDeMel.Domain.Commands.PedidoProduto;
using FavoDeMel.Domain.Core.Commands;
using FavoDeMel.Domain.Entities.Enums;

namespace FavoDeMel.Domain.Commands.Pedido
{
    public abstract class PedidoCommand : Command
    {
        public Guid IDPedido { get; set; }

        public DateTime DataPedido { get; set; }
        public SituacaoPedido Situacao { get; set; }

        public Guid IDGarcom { get; set; }

        public Guid IDComanda { get; set; }

        public List<AdicionarPedidoProdutoCommand> Produtos { get; set; }
    }
}