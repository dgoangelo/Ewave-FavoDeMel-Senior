using System.Collections.Generic;
using AutoMapper;
using FavoDeMel.Domain.Core.Notifications;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.Application.Mapeamentos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoDeMel.API.Controllers.Base
{
    public class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        public readonly IUnitOfWork UnitOfWork;
        protected IMapper MapperModelAndDto = AutoMapperConfiguration.GetMapper();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="unitOfWork"></param>
        public BaseController(
            INotificationHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _notifications = (DomainNotificationHandler)notifications;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected List<DomainNotification> GetValidations()
        {
            return _notifications.GetNotifications();
        }
    }
}