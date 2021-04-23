using FavoDeMel.Domain.Commands.Pedido;

namespace FavoDeMel.Domain.Validations.Pedido
{
    public class AlterarStatusPedidoValidation : PedidoValidation<PedidoCommand>
    {
        public AlterarStatusPedidoValidation()
        {
            ValidarId();
        }
    }
}