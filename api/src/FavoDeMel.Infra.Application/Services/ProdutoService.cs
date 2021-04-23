using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Domain.Commands.Produto;
using FavoDeMel.Domain.Entities.Dto;
using FavoDeMel.Domain.Services;
using FavoDeMel.Infra.Application.Interface.Finders;
using MediatR;

namespace FavoDeMel.Infra.Application.Services
{
    public class ProdutoService : BaseServices, IProdutoService
    {
        private readonly IProdutoFinder _produtoFinder;

        public ProdutoService(IMediator mediator,
            IProdutoFinder produtoFinder) : base(mediator)
        {
            _produtoFinder = produtoFinder;
        }

        public async Task<ProdutoDto> Criar(ProdutoDto dto)
        {
            var criarGarcomCommand = MapperModelAndDto.Map<CriarProdutoCommand>(dto);
            dto.IDProduto = await Mediator.Send(criarGarcomCommand);
            return dto;
        }

        public async Task<bool> Atualizar(ProdutoDto dto)
        {
            var criarGarcomCommand = MapperModelAndDto.Map<AtualizarProdutoCommand>(dto);
            return await Mediator.Send(criarGarcomCommand);
        }

        public async Task<ProdutoDto> ObterProduto(Guid id)
        {
            return await _produtoFinder.ObterProduto(id);
        }

        public async Task<IEnumerable<ProdutoDto>> ObterProdutos()
        {
            return await _produtoFinder.ObterProdutos();
        }
    }
}