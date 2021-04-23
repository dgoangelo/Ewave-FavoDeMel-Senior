using FavoDeMel.Domain.Commands.Garcom;

namespace FavoDeMel.Domain.Validations.Garcom
{
    public class AtualizarGarcomValidation : GarcomValidation<AtualizarGarcomCommand>
    {
        public AtualizarGarcomValidation()
        {
            ValidarId();
            ValidarNome();
            ValidarCpf();
        }
    }
}