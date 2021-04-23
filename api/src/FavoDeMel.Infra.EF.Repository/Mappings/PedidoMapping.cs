using FavoDeMel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infra.EF.Repository.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("IDPedido");

            builder.Property(c => c.DataPedido);
            builder.Property(c => c.Situacao);
            
            builder.HasOne(c => c.Garcom)
                .WithMany().HasForeignKey(c => c.IDGarcom);

            builder.HasOne(c => c.Comanda)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(c => c.IDComanda);
        }
    }
}