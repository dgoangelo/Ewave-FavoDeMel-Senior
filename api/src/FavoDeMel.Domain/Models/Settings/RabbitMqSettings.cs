using System.Text;
using Microsoft.Extensions.Configuration;

namespace FavoDeMel.Domain.Models.Settings
{
    public class RabbitMqSettings : SettingsBase
    {
        public readonly string Url;
        public readonly string Usuario;
        public readonly string Senha;
        public readonly string Vhost;

        public RabbitMqSettings(IConfiguration configuration)
        {
            Url = configuration[AppSettings.Keys.RabbitMq.Url];
            Usuario = configuration[AppSettings.Keys.RabbitMq.Usuario];
            Senha = configuration[AppSettings.Keys.RabbitMq.Senha];
            Vhost = configuration[AppSettings.Keys.RabbitMq.VirtualHost];
        }

        public override string ToString()
        {
            var strB = new StringBuilder();
            strB.AppendLine("___________________________________________");
            strB.AppendLine($"________{nameof(RabbitMqSettings)}__________");
            strB.AppendLine(MontarTextoChaveValor(nameof(Url), Url));
            strB.AppendLine(MontarTextoChaveValor(nameof(Usuario), Usuario));
            strB.AppendLine(MontarTextoChaveValor(nameof(Senha), Senha));
            strB.AppendLine(MontarTextoChaveValor(nameof(Vhost), Vhost));
            strB.AppendLine("___________________________________________");
            return strB.ToString();
        }
    }
}