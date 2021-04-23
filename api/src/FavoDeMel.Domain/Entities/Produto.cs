using FavoDeMel.Domain.Core.Entities;

namespace FavoDeMel.Domain.Entities
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}