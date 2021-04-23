using System;
using FavoDeMel.Domain.Validations.Comanda;
using MediatR;

namespace FavoDeMel.Domain.Commands.Comanda
{
    public class CriarComandaCommand : ComandaCommand , IRequest<Guid>
    {
        public override bool IsValid()
        {
            ValidationResult = new CriarComandaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}