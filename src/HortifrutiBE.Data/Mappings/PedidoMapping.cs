using HortifrutiBE.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortifrutiBE.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataCadastro)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(p => p.UltimaAtualizacao)
                .HasColumnType("DATETIME");

            builder.HasOne(t => t.Comprador)
                .WithMany(t => t.Pedidos)
                .HasForeignKey(t => t.IdComprador)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Navigation(p => p.Comprador)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.Entrega)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.ToTable("Pedidos");
        }
    }
}
