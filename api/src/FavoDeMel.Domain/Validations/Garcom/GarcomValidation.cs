using System;
using FavoDeMel.Domain.Commands.Garcom;
using FavoDeMel.Domain.ValueObjects;
using FluentValidation;

namespace FavoDeMel.Domain.Validations.Garcom
{
    public abstract class GarcomValidation<T> : AbstractValidator<T> where T : GarcomCommand
    {
        protected void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .Length(2, 255);
        }

        protected void ValidarCpf()
        {
            RuleFor(c => c.Cpf)
                .NotEmpty()
                .Length(11, 14);

            RuleFor(c => c.Cpf)
                .Must(Cpf.IsValid)
                .WithMessage(c => "O valor informado não é um CPF válido.");
        }

        protected void ValidarId()
        {
            RuleFor(c => c.IDGarcom)
                .NotEqual(Guid.Empty);
        }
    }
}