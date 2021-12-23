using HortifrutiBE.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortifrutiBE.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(p => p.UnidadeMedida)
                .HasColumnType("VARCHAR(10)")
                .IsRequired();

            builder.Property(p => p.Detalhes)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(p => p.UltimaAtualizacao)
                .HasColumnType("DATETIME");

            builder.HasOne(t => t.Hortifruti)
                .WithMany(t => t.Produtos)
                .HasForeignKey(t => t.IdHortifruti)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasIndex(p => new { p.IdHortifruti, p.Nome });

            builder.Navigation(p => p.Hortifruti)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.ItensEstoque)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.ToTable("Produtos");
        }
    }
}
