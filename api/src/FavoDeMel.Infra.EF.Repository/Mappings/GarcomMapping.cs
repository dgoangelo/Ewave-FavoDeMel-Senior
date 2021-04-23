using FavoDeMel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infra.EF.Repository.Mappings
{
    public class GarcomMapping : IEntityTypeConfiguration<Garcom>
    {
        public void Configure(EntityTypeBuilder<Garcom> builder)
        {
            builder.ToTable("Garcom");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("IDGarcom");

            builder.Property(c => c.Nome)
                .HasMaxLength(14);

            builder.Property(c => c.Cpf).IsUnicode();
        }
    }
}