using System;
using System.Threading;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Services
{
    public interface IRabbiqMqService
    {
        Task Send<T>(T obj, Uri queue, CancellationToken cancellationToken);
    }
}