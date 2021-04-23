using FavoDeMel.Domain.Commands.Garcom;

namespace FavoDeMel.Domain.Validations.Garcom
{
    public class CriarGarcomValidation : GarcomValidation<CriarGarcomCommand>
    {
        public CriarGarcomValidation()
        {
            ValidarNome();
            ValidarCpf();
        }
    }
}