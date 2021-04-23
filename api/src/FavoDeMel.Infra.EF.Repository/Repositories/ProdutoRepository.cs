using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Repository.Context;

namespace FavoDeMel.Infra.EF.Repository.Repositories
{
    public class ProdutoRepository : Repository<Produto> , IProdutoRepository
    {
        public ProdutoRepository(FavoDeMelContext context) : base(context)
        {
        }
    }
}