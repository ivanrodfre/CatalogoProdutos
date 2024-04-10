using Catalogo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Infra.Configurations
{
    public class ProdutoItemConfiguration : IEntityTypeConfiguration<ProdutoItem>
    {
        public void Configure(EntityTypeBuilder<ProdutoItem> builder)
        {
            builder.ToTable("Produtos");
            builder.Property(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(120)");
            builder.Property(x => x.Descricao).HasColumnType("VARCHAR(160)");
            builder.Property(x => x.Preco);
            builder.Property(x => x.DataCriacao);
        }
    }
}
