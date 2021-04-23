using System.Data;

namespace FavoDeMel.Infra.Application.Interface
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}