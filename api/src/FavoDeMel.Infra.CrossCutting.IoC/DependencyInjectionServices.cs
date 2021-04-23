using FavoDeMel.Domain.Services;
using FavoDeMel.Infra.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FavoDeMel.Infra.CrossCutting.IoC
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection RegisterServices(IServiceCollection services)
        {

            services.AddTransient<IGeradorGuidService, GeradorGuidService>();
            services.AddTransient<IGarcomService, GarcomService>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IComandaService, ComandaService>();
            services.AddTransient<IRabbiqMqService, RabbiqMqService>();
            services.AddTransient<ICozinhaService, CozinhaService>();
            
            return services;
        }
    }
}