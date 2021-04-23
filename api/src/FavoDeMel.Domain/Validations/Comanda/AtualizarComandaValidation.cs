using FavoDeMel.Domain.Commands.Comanda;

namespace FavoDeMel.Domain.Validations.Comanda
{
    public class AtualizarComandaValidation : ComandaValidation<ComandaCommand>
    {
        public AtualizarComandaValidation()
        {
            ValidarId();
            ValidarMesa();
        }
    }
}