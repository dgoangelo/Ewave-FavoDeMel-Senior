using System;
using System.Data;
using FavoDeMel.Infra.Application.Interface;
using Microsoft.Data.SqlClient;

namespace FavoDeMel.Infra.Dapper.Connection
{
    public abstract class SqlConnectionFactory : IDisposable, IConnectionFactory
    {
        private readonly string _connectionString;
        public IDbConnection DbConnection;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Create()
        {
            DbConnection = new SqlConnection(_connectionString);
            OpenConnectionIfClosed();
            return DbConnection;
        }

        private void OpenConnectionIfClosed()
        {
            if (DbConnection.State == ConnectionState.Closed)
                DbConnection.Open();
        }

        public void Dispose()
        {
            DbConnection?.Dispose();
        }
    }
}