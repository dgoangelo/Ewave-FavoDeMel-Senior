
using FavoDeMel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infra.EF.Repository.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("IDProduto");

            builder.Property(c => c.Nome).HasMaxLength(200);
            builder.Property(c => c.Valor).HasPrecision(19, 2);
        }
    }
}