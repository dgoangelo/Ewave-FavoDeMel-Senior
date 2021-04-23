using System;

namespace FavoDeMel.Domain.Services
{
    public interface IGeradorGuidService
    {
        Guid GetNexGuid();
    }
}