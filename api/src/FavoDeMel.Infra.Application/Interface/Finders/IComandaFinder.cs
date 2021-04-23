using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Domain.Entities.Dto;

namespace FavoDeMel.Infra.Application.Interface.Finders
{
    public interface IComandaFinder
    {
        Task<ComandaDto> ObterComanda(Guid id);
        Task<IEnumerable<ComandaDto>> ObterComanda();
    }
}