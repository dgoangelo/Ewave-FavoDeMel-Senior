using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Domain.Entities.Dto;

namespace FavoDeMel.Infra.Application.Interface.Finders
{
    public interface IProdutoFinder
    {
        Task<ProdutoDto> ObterProduto(Guid id);
        Task<IEnumerable<ProdutoDto>> ObterProdutos();
    }
}