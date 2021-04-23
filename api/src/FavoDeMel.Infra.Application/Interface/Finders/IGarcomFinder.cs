using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Domain.Entities.Dto;

namespace FavoDeMel.Infra.Application.Interface.Finders
{
    public interface IGarcomFinder
    {
        Task<GarcomDto> ObterGarcomPorId(Guid id);
        Task<GarcomDto> ObterGarcomPorCpf(string cpf);
        Task<IEnumerable<GarcomDto>> ObterGarcoms();
    }
}