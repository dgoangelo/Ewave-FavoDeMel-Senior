using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Domain.Entities.Dto;

namespace FavoDeMel.Infra.Application.Interface.Finders
{
    public interface IPedidoFinder
    {
        Task<IEnumerable<PedidoDto>> ObterPedidos();
        Task<PedidoDto> ObterPedido(Guid id);
    }
}