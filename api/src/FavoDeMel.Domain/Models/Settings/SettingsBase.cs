using FavoDeMel.Domain.ExtensionsMethods;

namespace FavoDeMel.Domain.Models.Settings
{
    public abstract class SettingsBase
    {
        protected string MontarTextoChaveValor(string chave, string valor)
        {
            var str = valor.IsNotEmpty() ? $"{chave}: {valor}" : $"{chave} não encontrado.";
            return str;
        }
    }
}