using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Repository.Context;

namespace FavoDeMel.Infra.EF.Repository.Repositories
{
    public class ComandaRepository  : Repository<Comanda> , IComandaRepository
    {
        public ComandaRepository(FavoDeMelContext context) : base(context)
        {
        }
    }
}