using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Domain.Entities.Dto;

namespace FavoDeMel.Domain.Services
{
    public interface IGarcomService
    {
        Task<GarcomDto> Criar(GarcomDto dto);
        Task<bool> Atualizar(GarcomDto dto);
        Task<GarcomDto> ObterGarcomPorId(Guid id);
        Task<GarcomDto> ObterGarcomPorCpf(string cpf);
        Task<IEnumerable<GarcomDto>> ObterGarcoms();
    }
}