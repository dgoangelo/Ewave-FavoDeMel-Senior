using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Repository.Context;

namespace FavoDeMel.Infra.EF.Repository.Repositories
{
    public class GarcomRepository : Repository<Garcom>, IGarcomRepository
    {
        public GarcomRepository(FavoDeMelContext context) : base(context)
        {
        }
    }
}