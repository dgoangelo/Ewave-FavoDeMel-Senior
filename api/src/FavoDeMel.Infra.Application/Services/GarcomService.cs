using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Domain.Commands.Garcom;
using FavoDeMel.Domain.Entities.Dto;
using FavoDeMel.Domain.Services;
using FavoDeMel.Infra.Application.Interface.Finders;
using MediatR;

namespace FavoDeMel.Infra.Application.Services
{
    public class GarcomService : BaseServices, IGarcomService
    {
        private readonly IGarcomFinder _garcomFinder;

        public GarcomService(IMediator mediator,
            IGarcomFinder garcomFinder) : base(mediator)
        {
            _garcomFinder = garcomFinder;
        }

        public async Task<GarcomDto> Criar(GarcomDto dto)
        {
            var criarGarcomCommand = MapperModelAndDto.Map<CriarGarcomCommand>(dto);
            dto.IDGarcom = await Mediator.Send(criarGarcomCommand);
            return dto;
        }

        public async Task<bool> Atualizar(GarcomDto dto)
        {
            var atualizacaoGarcomCommand = MapperModelAndDto.Map<AtualizarGarcomCommand>(dto);
            return await Mediator.Send(atualizacaoGarcomCommand);
        }
        
        public async Task<GarcomDto> ObterGarcomPorId(Guid id)
        {
            return await _garcomFinder.ObterGarcomPorId(id);
        }

        public async Task<GarcomDto> ObterGarcomPorCpf(string cpf)
        {
            return await _garcomFinder.ObterGarcomPorCpf(cpf);
        }

        public async Task<IEnumerable<GarcomDto>> ObterGarcoms()
        {
            return await _garcomFinder.ObterGarcoms();
        }
    }
}