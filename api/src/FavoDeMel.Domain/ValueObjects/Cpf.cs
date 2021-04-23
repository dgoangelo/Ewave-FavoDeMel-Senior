using System.Linq;
using FavoDeMel.Domain.Exceptions;

namespace FavoDeMel.Domain.ValueObjects
{
    public class Cpf
    {
        private readonly string _numero;

        public static bool IsValid(string cpf)
        {
            try
            {
                var cpfLimpo = LimparFormatacao(cpf);

                if (cpfLimpo?.Length != 11)
                    return false;

                if (SaoDigitosRepetidos(cpfLimpo))
                    return false;

                var digito = CalcularDigitoVerificador(cpfLimpo);

                return cpfLimpo.EndsWith(digito);
            }
            catch
            {
                return false;
            }
        }

        public Cpf(string numero)
        {
            if (!IsValid(numero))
            {
                throw new CpfInvalidoException(numero);
            }

            _numero = LimparFormatacao(numero);
        }

        public override string ToString()
        {
            return _numero;
        }

        private static string LimparFormatacao(string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace("-", "").Trim();
        }

        private static bool SaoDigitosRepetidos(string numero)
        {
            var firstDigit = numero[0];
            return numero.All(digito => digito == firstDigit);
        }

        private static string CalcularDigitoVerificador(string numero)
        {
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var tempCpf = numero.Substring(0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;
            resto = (resto < 2) ? 0 : 11 - resto;
            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            resto = (resto < 2) ? 0 : 11 - resto;
            digito = digito + resto;

            return digito;
        }
    }
}