using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Domain.Entities.Dto;

namespace FavoDeMel.Domain.Services
{
    public interface IComandaService
    {
        Task<ComandaDto> Criar(ComandaDto dto);
        Task<bool> Atualizar(ComandaDto dto);
        Task<ComandaDto> ObterComandaPorId(Guid id);
        Task<IEnumerable<ComandaDto>> ObterComandas();
    }
}