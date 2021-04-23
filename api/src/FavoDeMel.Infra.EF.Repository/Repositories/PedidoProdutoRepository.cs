using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Repository.Context;

namespace FavoDeMel.Infra.EF.Repository.Repositories
{
    public class PedidoProdutoRepository : Repository<PedidoProduto> , IPedidoProdutoRepository
    {
        public PedidoProdutoRepository(FavoDeMelContext context) : base(context)
        {
        }
    }
}