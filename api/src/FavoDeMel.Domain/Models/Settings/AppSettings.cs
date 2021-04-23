using System.Text;

namespace FavoDeMel.Domain.Models.Settings
{
    public class AppSettings
    {
        #region Keys

        public static class Keys
        {
            public static class Swagger
            {
                public const string TITLE = "Swagger:App:Title";
                public const string DESCRIPTION = "Swagger:App:Description";
                public const string VERSION = "Swagger:App:Version";
            }

            public static class RabbitMq
            {
                public const string Url = "RABBITMQ:URL";
                public const string Usuario = "RABBITMQ:USUARIO";
                public const string Senha = "RABBITMQ:SENHA";
                public const string VirtualHost = "RABBITMQ:VHOST";
            }

            public static class ConnectionStrings
            {
                public const string FAVODEMEL_CONNECTION = "FAVODEMEL_CONNECTION_STRING";
            }
        }

        #endregion

        public SwaggerSettings Swagger { get; set; }
        public DataSettings Data { get; set; }
        public RabbitMqSettings RabbitMq { get; set; }

        public override string ToString()
        {
            var strB = new StringBuilder();
            
            strB.AppendLine(Data.ToString());
            strB.AppendLine(RabbitMq.ToString());

            return strB.ToString();
        }
    }
}