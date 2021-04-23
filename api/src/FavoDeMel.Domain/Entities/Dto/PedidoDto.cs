using System;
using System.Collections.Generic;
using FavoDeMel.Domain.Entities.Enums;

namespace FavoDeMel.Domain.Entities.Dto
{
    public class PedidoDto
    {
        public Guid IDPedido { get; set; }
        public DateTime DataPedido { get; set; }

        public Guid IDGarcom { get; set; }
        public GarcomDto Garcom { get; set; }

        public Guid IDComanda { get; set; }
        public ComandaDto Comanda { get; set; }

        public SituacaoPedido SituacaoPedido { get; set; }

        public List<PedidoProdutoDto> Produtos { get; set; }

        public PedidoDto()
        {
            Produtos = new List<PedidoProdutoDto>();
        }
    }
}