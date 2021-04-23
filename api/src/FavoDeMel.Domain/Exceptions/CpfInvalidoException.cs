using System;

namespace FavoDeMel.Domain.Exceptions
{
    public class CpfInvalidoException : Exception
    {
        public CpfInvalidoException(string cpfInvalido) : base($"O valor '{cpfInvalido}' informado não é um CPF válido.")
        {
        }
    }
}