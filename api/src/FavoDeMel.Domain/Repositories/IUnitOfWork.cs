using System;

namespace FavoDeMel.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}