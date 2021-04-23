using System;
using System.Threading.Tasks;
using FavoDeMel.API.Controllers.Base;
using FavoDeMel.API.Utils;
using FavoDeMel.Domain.Core.Notifications;
using FavoDeMel.Domain.Entities.Dto;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoDeMel.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route(Endpoints.Recursos.Produto)]
    [ApiController]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _produtoService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="produtoService"></param>
        public ProdutoController(
            INotificationHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork, IProdutoService produtoService) : base(notifications, unitOfWork)
        {
            _produtoService = produtoService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Endpoints.Route.GET_ALL)]
        public async Task<IActionResult> ObterProdutos()
        {
            var produtos = await _produtoService.ObterProdutos();
            return Ok(produtos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Endpoints.Route.GET_BY_ID)]
        public async Task<IActionResult> ObterProduto(Guid id)
        {
            var produto = await _produtoService.ObterProduto(id);
            return Ok(produto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(Endpoints.Route.POST)]
        public async Task<IActionResult> CriarProduto(ProdutoDto dto)
        {
            var produto = await _produtoService.Criar(dto);

            if (!IsValidOperation())
                return BadRequest(GetValidations());

            UnitOfWork.Commit();

            return Ok(produto);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> AtualizarProduto(ProdutoDto dto)
        {
            var produto = await _produtoService.Atualizar(dto);

            if (!IsValidOperation())
                return BadRequest(GetValidations());

            UnitOfWork.Commit();

            return Ok(produto);
        }
    }
}