using System.Threading.Tasks;
using FavoDeMel.Domain.Entities.Dto;

namespace FavoDeMel.Domain.Services
{
    public interface ICozinhaService
    {
        Task<bool> AlterarStatusPedido(PedidoDto dto);
    }
}