using System.Text;
using Microsoft.Extensions.Configuration;

namespace FavoDeMel.Domain.Models.Settings
{
    public class DataSettings : SettingsBase
    {
        public readonly string FavoDeMelConnection;

        public DataSettings(IConfiguration configuration)
        {
            FavoDeMelConnection = configuration[AppSettings.Keys.ConnectionStrings.FAVODEMEL_CONNECTION];
        }

        public override string ToString()
        {
            var strB = new StringBuilder();
            strB.AppendLine("___________________________________________");
            strB.AppendLine($"________{nameof(DataSettings)}__________");
            strB.AppendLine(MontarTextoChaveValor(nameof(FavoDeMelConnection), FavoDeMelConnection));
            strB.AppendLine("___________________________________________");
            return strB.ToString();
        }
    }
}