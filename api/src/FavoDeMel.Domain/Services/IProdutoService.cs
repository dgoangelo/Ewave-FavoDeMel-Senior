using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Domain.Entities.Dto;

namespace FavoDeMel.Domain.Services
{
    public interface IProdutoService
    {
        Task<ProdutoDto> Criar(ProdutoDto dto);
        Task<bool> Atualizar(ProdutoDto dto);
        Task<ProdutoDto> ObterProduto(Guid id);
        Task<IEnumerable<ProdutoDto>> ObterProdutos();
    }
}