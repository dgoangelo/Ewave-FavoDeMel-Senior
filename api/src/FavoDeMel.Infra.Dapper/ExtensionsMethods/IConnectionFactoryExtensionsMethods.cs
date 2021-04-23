using System.Data;
using FavoDeMel.Infra.Application.Interface;

namespace FavoDeMel.Infra.Dapper.ExtensionsMethods
{
    public static class ConnectionFactoryExtensionsMethods
    {
        public static IDbConnection CreateManaged(this IConnectionFactory source)
        {
            return source.Create();
        }
    }
}