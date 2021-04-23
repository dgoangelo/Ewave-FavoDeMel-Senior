using FavoDeMel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infra.EF.Repository.Mappings
{
    public class PedidoProdutoMapping : IEntityTypeConfiguration<PedidoProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoProduto> builder)
        {
            builder.ToTable("PedidoProduto");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("IDPedidoProduto");

            builder.Property(c => c.Quantidade);
            builder.Property(c => c.ValorTotal).HasPrecision(19, 2);

            builder
                .Property(c => c.IDProduto)
                .IsRequired();

            builder
                .Property(c => c.IDPedido)
                .IsRequired();

            builder.HasOne(c => c.Produto)
                .WithMany()
                .HasForeignKey(c => c.IDProduto);

            builder.HasOne(c => c.Pedido)
                .WithMany(c => c.PedidoProdutos)
                .HasForeignKey(c => c.IDPedido);
        }
    }
}