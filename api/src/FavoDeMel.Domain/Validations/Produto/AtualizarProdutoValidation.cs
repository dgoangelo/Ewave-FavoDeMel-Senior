using FavoDeMel.Domain.Commands.Produto;

namespace FavoDeMel.Domain.Validations.Produto
{
    public class AtualizarProdutoValidation : ProdutoValidation<AtualizarProdutoCommand>
    {
        public AtualizarProdutoValidation()
        {
            ValidarNome();
            ValidarValor();
            ValidarId();
        }
    }
}