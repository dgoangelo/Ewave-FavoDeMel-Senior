using System;
using FavoDeMel.Infra.Application.Interface;

namespace FavoDeMel.Infra.Dapper.Abstractions
{
    public abstract class FinderSql
    {
        protected IConnectionFactory ConnectionFactory;
        protected FinderSql(IConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory ?? throw new ArgumentException(nameof(connectionFactory));
        }
    }
}