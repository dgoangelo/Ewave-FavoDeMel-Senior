using System;
using System.Threading.Tasks;
using FavoDeMel.API.Controllers.Base;
using FavoDeMel.API.Utils;
using FavoDeMel.Domain.Core.Notifications;
using FavoDeMel.Domain.Entities.Dto;
using FavoDeMel.Domain.Models;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoDeMel.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route(Endpoints.Recursos.Pedido)]
    [ApiController]
    public class PedidoController : BaseController
    {

        private readonly IPedidoService _pedidoService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="pedidoService"></param>
        public PedidoController(
            INotificationHandler<DomainNotification> notifications,
            IUnitOfWork unitOfWork, IPedidoService pedidoService) : base(notifications, unitOfWork)
        {
            _pedidoService = pedidoService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Endpoints.Route.GET_ALL)]
        public async Task<IActionResult> ObterPedidos()
        {
            var pedidos = await _pedidoService.ObterPedidos();
            return Ok(pedidos);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Endpoints.Route.GET_BY_ID)]
        public async Task<IActionResult> ObterPedido(Guid id)
        {
            var pedido = await _pedidoService.ObterPedido(id);
            return Ok(pedido);
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(Endpoints.Route.POST)]
        public async Task<IActionResult> CriarPedido(PedidoViewModel viewModel)
        {
            var dto = MapperModelAndDto.Map<PedidoDto>(viewModel);

            var pedido = await _pedidoService.Criar(dto);

            if (!IsValidOperation())
                return BadRequest(GetValidations());

            UnitOfWork.Commit();

            return Ok(pedido);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPedido"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{idPedido}/adicionar-produto")]

        public async Task<IActionResult> AdicionarProdutoPedido(Guid idPedido, PedidoProdutoViewModel viewModel)
        {
            viewModel.IDPedido = idPedido;
            var dto = MapperModelAndDto.Map<PedidoProdutoDto>(viewModel);

            var pedidoProduto = await _pedidoService.AdicionarProdutoPedido(dto);

            if (!IsValidOperation())
                return BadRequest(GetValidations());

            UnitOfWork.Commit();

            return Ok(pedidoProduto);
        }
    }
}