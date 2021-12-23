using HortifrutiBE.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortifrutiBE.Data.Mappings
{
    public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataCadastro)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(p => p.UltimaAtualizacao)
                .HasColumnType("DATETIME");

            builder.HasOne(t => t.ItemEstoque)
                .WithOne(t => t.ItemPedido)
                .HasForeignKey<ItemPedido>(t => t.IdItemEstoque)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(t => t.Pedido)
                .WithMany(t => t.ItensPedido)
                .HasForeignKey(t => t.IdPedido)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Navigation(p => p.ItemEstoque)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.Pedido)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.ToTable("ItensPedido");
        }
    }
}
