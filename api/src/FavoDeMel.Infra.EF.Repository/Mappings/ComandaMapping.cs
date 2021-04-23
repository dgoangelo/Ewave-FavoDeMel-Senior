using FavoDeMel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infra.EF.Repository.Mappings
{
    public class ComandaMapping : IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            builder.ToTable("Comanda");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("IDComanda");
            builder.Property(c => c.DataCriacao);
            builder.Property(c => c.Mesa);
            builder.Property(c => c.Status);
        }
    }
}