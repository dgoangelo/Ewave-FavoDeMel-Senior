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
    [Route(Endpoints.Recursos.Garcom)]
    [ApiController]
    public class GarcomController : BaseController
    {
        private readonly IGarcomService _garcomService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="garcomService"></param>
        public GarcomController(
            INotificationHandler<DomainNotification> notifications,
            IUnitOfWork unitOfWork,
            IGarcomService garcomService) : base(notifications, unitOfWork)
        {
            _garcomService = garcomService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Endpoints.Route.GET_ALL)]
        public async Task<IActionResult> ObterGarcoms()
        {
            var garcoms = await _garcomService.ObterGarcoms();
            return Ok(garcoms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Endpoints.Route.GET_BY_ID)]
        public async Task<IActionResult> ObterGarcom(Guid id)
        {
            var garcom = await _garcomService.ObterGarcomPorId(id);
            return Ok(garcom);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route(Endpoints.Route.POST)]
        public async Task<IActionResult> CriarGarcom(GarcomDto dto)
        {
            var garcom = await _garcomService.Criar(dto);

            if (!IsValidOperation())
                return BadRequest(GetValidations());

            UnitOfWork.Commit();

            return Ok(garcom);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> AtualizarGarcom(GarcomDto dto)
        {
            var garcom = await _garcomService.Atualizar(dto);

            if (!IsValidOperation())
                return BadRequest(GetValidations());

            UnitOfWork.Commit();

            return Ok(garcom);
        }
    }
}