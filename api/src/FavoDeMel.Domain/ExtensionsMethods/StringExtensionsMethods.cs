using System;

namespace FavoDeMel.Domain.ExtensionsMethods
{
    public static class StringExtensionsMethods
    {
        public static bool IsEmpty(this string texto)
        {
            return texto == null || String.IsNullOrWhiteSpace(texto);
        }

        public static bool IsNotEmpty(this string texto)
        {
            return !texto.IsEmpty();
        }

        public static string QuebrarTexto(this string texto, int tamanho = 60)
        {
            if (texto.IsEmpty())
                return string.Empty;

            if (texto.Length > tamanho)
                return $"{texto.Substring(0, tamanho)}...";

            return texto;
        }

        public static bool Possui(this string texto, string partial)
        {
            return texto.Contains(partial, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}