using FavoDeMel.Domain.Validations.Garcom;
using MediatR;

namespace FavoDeMel.Domain.Commands.Garcom
{
    public class AtualizarGarcomCommand : GarcomCommand, IRequest<bool>
    {
        public override bool IsValid()
        {
            ValidationResult = new AtualizarGarcomValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}