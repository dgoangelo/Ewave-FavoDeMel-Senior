using FavoDeMel.Domain.Models.Settings;
using FavoDeMel.Infra.Application.Interface;
using Microsoft.Extensions.Configuration;

namespace FavoDeMel.Infra.Dapper.Connection
{
    public class FavoDeMelConnectionFactory : SqlConnectionFactory, IFavoDeMelConnectionFactory
    {
        public FavoDeMelConnectionFactory(IConfiguration configuration) : base(configuration[AppSettings.Keys.ConnectionStrings.FAVODEMEL_CONNECTION])
        {
        }
    }
}