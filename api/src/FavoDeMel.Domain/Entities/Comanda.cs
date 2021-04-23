using System;
using System.Collections.Generic;
using FavoDeMel.Domain.Core.Entities;
using FavoDeMel.Domain.Entities.Enums;

namespace FavoDeMel.Domain.Entities
{
    public class Comanda : Entity
    {
        public DateTime DataCriacao { get; set; }

        public int Mesa { get; set; }

        public Status Status { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}