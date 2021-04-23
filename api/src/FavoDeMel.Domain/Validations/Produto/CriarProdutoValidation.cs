using FavoDeMel.Domain.Commands.Produto;

namespace FavoDeMel.Domain.Validations.Produto
{
    public class CriarProdutoValidation : ProdutoValidation<CriarProdutoCommand>
    {
        public CriarProdutoValidation()
        {
            ValidarNome();
            ValidarValor();
        }
    }
}