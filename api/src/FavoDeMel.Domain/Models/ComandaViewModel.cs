using System;
using FavoDeMel.Domain.Entities.Enums;

namespace FavoDeMel.Domain.Models
{
    public class ComandaViewModel
    {
        public Guid IDComanda { get; set; }
        public int Mesa { get; set; }
        public Status Status { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}