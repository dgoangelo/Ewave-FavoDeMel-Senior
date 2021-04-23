using System;
using System.Linq;
using FavoDeMel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FavoDeMel.Infra.EF.Repository.Context
{
    public class FavoDeMelContext : DbContext
    {
        public DbSet<Garcom> Garcoms { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }


        public FavoDeMelContext(DbContextOptions<FavoDeMelContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var currentAssembly = typeof(FavoDeMelContext).Assembly;
            var efMappingTypes = currentAssembly.GetTypes().Where(t =>
                t.FullName.StartsWith("FavoDeMel.Infra.EF.Repository.Mappings.") &&
                t.FullName.EndsWith("Mapping"));

            foreach (var map in efMappingTypes.Select(Activator.CreateInstance))
            {
                modelBuilder.ApplyConfiguration((dynamic)map);
            }
        }
    }
}