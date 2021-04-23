using AutoMapper;
using FavoDeMel.Infra.Application.Mapeamentos;
using MediatR;


namespace FavoDeMel.Infra.Application.Services
{
    public abstract class BaseServices
    {
        protected IMapper MapperModelAndDto = AutoMapperConfiguration.GetMapper();
        protected IMediator Mediator;

        protected BaseServices(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}