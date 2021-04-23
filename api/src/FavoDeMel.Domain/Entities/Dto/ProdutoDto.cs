using System;

namespace FavoDeMel.Domain.Entities.Dto
{
    public class ProdutoDto
    {
        public Guid IDProduto { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}