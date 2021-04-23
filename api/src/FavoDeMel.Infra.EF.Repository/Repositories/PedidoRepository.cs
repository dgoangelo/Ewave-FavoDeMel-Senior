using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Repository.Context;

namespace FavoDeMel.Infra.EF.Repository.Repositories
{
    public class PedidoRepository : Repository<Pedido> , IPedidoRepository
    {
        public PedidoRepository(FavoDeMelContext context) : base(context)
        {
        }
    }
}