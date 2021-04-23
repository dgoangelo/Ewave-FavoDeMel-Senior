using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Domain.Commands.Comanda;
using FavoDeMel.Domain.Entities.Dto;
using FavoDeMel.Domain.Services;
using FavoDeMel.Infra.Application.Interface.Finders;
using MediatR;

namespace FavoDeMel.Infra.Application.Services
{
    public class ComandaService : BaseServices, IComandaService
    {
        private readonly IComandaFinder _comandaFinder;

        public ComandaService(IMediator mediator, IComandaFinder comandaFinder) : base(mediator)
        {
            _comandaFinder = comandaFinder;
        }

        public async Task<ComandaDto> Criar(ComandaDto dto)
        {
            var criarComandaCommand = MapperModelAndDto.Map<CriarComandaCommand>(dto);
            dto.IDComanda = await Mediator.Send(criarComandaCommand);
            return dto;
        }

        public async Task<bool> Atualizar(ComandaDto dto)
        {
            var atualizarComandaCommand = MapperModelAndDto.Map<AtualizarComandaCommand>(dto);
           return await Mediator.Send(atualizarComandaCommand);
        }

        public async Task<ComandaDto> ObterComandaPorId(Guid id)
        {
            return await _comandaFinder.ObterComanda(id);
        }

        public async Task<IEnumerable<ComandaDto>> ObterComandas()
        {
            return await _comandaFinder.ObterComanda();
        }
    }
}