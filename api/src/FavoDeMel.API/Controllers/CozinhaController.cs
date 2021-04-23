using System;
using System.Threading.Tasks;
using FavoDeMel.API.Controllers.Base;
using FavoDeMel.API.Utils;
using FavoDeMel.Domain.Core.Notifications;
using FavoDeMel.Domain.Entities.Dto;
using FavoDeMel.Domain.Entities.Enums;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoDeMel.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route(Endpoints.Recursos.Cozinhda)]
    [ApiController]
    public class CozinhaController : BaseController
    {
        private readonly ICozinhaService _cozinhaService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="cozinhaService"></param>
        public CozinhaController(INotificationHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork, ICozinhaService cozinhaService) : base(notifications, unitOfWork)
        {
            _cozinhaService = cozinhaService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("pedido/{idPedido}/status/preparando")]
        public async Task<IActionResult> StatusPedidoPreparando(Guid idPedido)
        {
            var dto = new PedidoDto {IDPedido = idPedido, SituacaoPedido = SituacaoPedido.Preparando};
            var produto = await _cozinhaService.AlterarStatusPedido(dto);

            if (!IsValidOperation())
                return BadRequest(GetValidations());

            UnitOfWork.Commit();

            return Ok(produto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("pedido/{idPedido}/status/finalizado")]
        public async Task<IActionResult> StatusPedidoFinalizado(Guid idPedido)
        {
            var dto = new PedidoDto { IDPedido = idPedido, SituacaoPedido = SituacaoPedido.Finalizado };
            var produto = await _cozinhaService.AlterarStatusPedido(dto);

            if (!IsValidOperation())
                return BadRequest(GetValidations());

            UnitOfWork.Commit();

            return Ok(produto);
        }

    }
}