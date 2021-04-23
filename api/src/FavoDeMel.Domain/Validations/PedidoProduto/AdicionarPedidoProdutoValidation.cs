using FavoDeMel.Domain.Commands.PedidoProduto;

namespace FavoDeMel.Domain.Validations.PedidoProduto
{
    public class AdicionarPedidoProdutoValidation : PedidoProdutoValidation<PedidoProdutoCommand>
    {
        public AdicionarPedidoProdutoValidation()
        {
            ValidarQuantidade();
            ValidarIdPedido();
            ValidarIdProduto();
        }
    }
}