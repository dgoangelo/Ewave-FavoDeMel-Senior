using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Domain.Entities.Dto;

namespace FavoDeMel.Domain.Services
{
    public interface IPedidoService
    {
        Task<PedidoDto> Criar(PedidoDto dto);

        Task<IEnumerable<PedidoDto>> ObterPedidos();
        Task<PedidoDto> ObterPedido(Guid id);

        Task<bool> AdicionarProdutoPedido(PedidoProdutoDto dto);
    }
}