using System;
using FavoDeMel.Domain.Core.Commands;
using FavoDeMel.Domain.Entities.Enums;

namespace FavoDeMel.Domain.Commands.Comanda
{
    public abstract class ComandaCommand : Command
    {
        public Guid IDComanda { get; set; }
        public int Mesa { get; set; }
        public Status Status { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}