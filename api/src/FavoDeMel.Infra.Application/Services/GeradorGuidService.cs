using System;
using FavoDeMel.Domain.Services;
using MassTransit;

namespace FavoDeMel.Infra.Application.Services
{
    public class GeradorGuidService : IGeradorGuidService
    {
        public Guid GetNexGuid()
        {
            return new Guid(NewId.Next().ToString("D").ToUpperInvariant());
        }
    }
}