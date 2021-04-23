using FavoDeMel.Domain.Validations.Comanda;
using MediatR;

namespace FavoDeMel.Domain.Commands.Comanda
{
    public class AtualizarComandaCommand : ComandaCommand, IRequest<bool>
    {
        public override bool IsValid()
        {
            ValidationResult = new AtualizarComandaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}