using FavoDeMel.Domain.Commands.Comanda;

namespace FavoDeMel.Domain.Validations.Comanda
{
    public class CriarComandaValidation : ComandaValidation<ComandaCommand>
    {
        public CriarComandaValidation()
        {
            ValidarMesa();
        }
    }
}