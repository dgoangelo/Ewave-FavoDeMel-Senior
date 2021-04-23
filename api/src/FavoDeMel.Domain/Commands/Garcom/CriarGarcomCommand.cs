using System;
using FavoDeMel.Domain.Validations.Garcom;
using MediatR;

namespace FavoDeMel.Domain.Commands.Garcom
{
    public class CriarGarcomCommand : GarcomCommand, IRequest<Guid>
    {
        public override bool IsValid()
        {
            ValidationResult = new CriarGarcomValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}