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
    [Route(Endpoints.Recursos.Comanda)]
    [ApiController]
    public class ComandaController : BaseController
    {
        private readonly IComandaService _comandaService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="comandaService"></param>
        public ComandaController(
            INotificationHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork, IComandaService comandaService) : base(notifications, unitOfWork)
        {
            _comandaService = comandaService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Endpoints.Route.GET_ALL)]
        public async Task<IActionResult> ObterComandas()
        {
            var comandas = await _comandaService.ObterComandas();
            return Ok(comandas);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Endpoints.Route.GET_BY_ID)]
        public async Task<IActionResult> ObterComanda(Guid id)
        {
            var comanda = await _comandaService.ObterComandaPorId(id);
            return Ok(comanda);
        }

        /// <summary>
        /// 
        /// </summary>
        
        /// <returns></returns>
        [HttpPost]
        [Route(Endpoints.Route.POST)]
        public async Task<IActionResult> CriarComanda(ComandaViewModel viewModel)
        {
            var dto = MapperModelAndDto.Map<ComandaDto>(viewModel);
            var comanda = await _comandaService.Criar(dto);

            if (!IsValidOperation())
                return BadRequest(GetValidations());

            UnitOfWork.Commit();

            return Ok(comanda);
        }
    }
}