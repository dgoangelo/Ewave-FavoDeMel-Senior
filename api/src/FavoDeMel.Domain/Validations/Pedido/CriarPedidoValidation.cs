using FavoDeMel.Domain.Commands.Pedido;

namespace FavoDeMel.Domain.Validations.Pedido
{
    public class CriarPedidoValidation : PedidoValidation<PedidoCommand>
    {
        public CriarPedidoValidation()
        {
            ValidarIdComanda();
            ValidarIdGarcom();
        }
    }
}