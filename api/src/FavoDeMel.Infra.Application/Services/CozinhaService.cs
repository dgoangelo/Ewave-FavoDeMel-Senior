using System.Threading.Tasks;
using FavoDeMel.Domain.Commands.Pedido;
using FavoDeMel.Domain.Entities.Dto;
using FavoDeMel.Domain.Services;
using MediatR;

namespace FavoDeMel.Infra.Application.Services
{
    public class CozinhaService : BaseServices, ICozinhaService
    {
        public CozinhaService(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> AlterarStatusPedido(PedidoDto dto)
        {
            var alterarStatusPedido = MapperModelAndDto.Map<AlterarStatusPedidoCommand>(dto);
            return await Mediator.Send(alterarStatusPedido);
        }
    }
}