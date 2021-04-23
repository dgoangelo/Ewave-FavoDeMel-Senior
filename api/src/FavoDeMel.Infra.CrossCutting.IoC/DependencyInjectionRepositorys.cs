using FavoDeMel.Domain.Models.Settings;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Repository.Context;
using FavoDeMel.Infra.EF.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FavoDeMel.Infra.CrossCutting.IoC
{
    public static class DependencyInjectionRepositorys
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContext<FavoDeMelContext>(options =>
                options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(appSettings.Data.FavoDeMelConnection));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<FavoDeMelContext>();

            services.AddScoped<IGarcomRepository, GarcomRepository>();
            services.AddScoped<IComandaRepository, ComandaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoProdutoRepository, PedidoProdutoRepository>();

            return services;
        }
    }
}