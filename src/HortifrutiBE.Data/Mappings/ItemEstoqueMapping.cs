using HortifrutiBE.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortifrutiBE.Data.Mappings
{
    public class ItemEstoqueMapping : IEntityTypeConfiguration<ItemEstoque>
    {
        public void Configure(EntityTypeBuilder<ItemEstoque> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Valor)
                .HasColumnType("DECIMAL(6,2)")
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(p => p.UltimaAtualizacao)
                .HasColumnType("DATETIME");

            builder.HasOne(p => p.Produto)
                .WithMany(p => p.ItensEstoque)
                .HasForeignKey(p => p.IdProduto)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Navigation(p => p.Produto)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.ItemPedido)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.ToTable("ItensEstoque");
        }
    }
}
