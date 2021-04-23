using System;
using FavoDeMel.Domain.CommandHandlers;
using FavoDeMel.Domain.Commands.Comanda;
using FavoDeMel.Domain.Commands.Garcom;
using FavoDeMel.Domain.Commands.Pedido;
using FavoDeMel.Domain.Commands.PedidoProduto;
using FavoDeMel.Domain.Commands.Produto;
using FavoDeMel.Domain.Core.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FavoDeMel.Infra.CrossCutting.IoC
{
    public static class DependencyInjectionCommandHandle
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            
            services.AddScoped<IRequestHandler<CriarGarcomCommand, Guid>, GarcomCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarGarcomCommand, bool>, GarcomCommandHandler>();
            
            services.AddScoped<IRequestHandler<CriarProdutoCommand, Guid>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarProdutoCommand, bool>, ProdutoCommandHandler>();

            services.AddScoped<IRequestHandler<CriarComandaCommand, Guid>, ComandaCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarComandaCommand, bool>, ComandaCommandHandler>();
            
            services.AddScoped<IRequestHandler<CriarPedidoCommand, Guid>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarStatusPedidoCommand, bool>, PedidoCommandHandler>();

            services.AddScoped<IRequestHandler<AdicionarPedidoProdutoCommand, bool>, PedidoProdutoCommandHandler>();

            services.AddScoped<IRequestHandler<CriarProdutoCommand, Guid>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarProdutoCommand, bool>, ProdutoCommandHandler>();
  
            return services;
        }
    }
}