using System;
using System.Collections.Generic;
using FavoDeMel.Domain.Entities.Enums;

namespace FavoDeMel.Domain.Entities.Dto
{
    public class ComandaDto
    {
        public Guid IDComanda { get; set; }
        public int Mesa { get; set; }
        public Status Status { get; set; }
        public DateTime DataCriacao { get; set; }

        public List<PedidoDto> Pedidos { get; set; }

        public ComandaDto()
        {
            Pedidos = new List<PedidoDto>();
        }
        
    }
}