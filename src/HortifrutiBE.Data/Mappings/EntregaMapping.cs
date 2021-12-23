using HortifrutiBE.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortifrutiBE.Data.Mappings
{
    public class EntregaMapping : IEntityTypeConfiguration<Entrega>
    {
        public void Configure(EntityTypeBuilder<Entrega> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Status)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(p => p.Envio)
                .HasColumnType("DATETIME");

            builder.Property(p => p.Recebimento)
                .HasColumnType("DATETIME");

            builder.Property(p => p.DataCadastro)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(p => p.UltimaAtualizacao)
                .HasColumnType("DATETIME");

            builder.HasOne(t => t.Pedido)
                .WithOne(t => t.Entrega)
                .HasForeignKey<Entrega>(t => t.IdPedido)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(t => t.Endereco)
                .WithMany(t => t.Entregas)
                .HasForeignKey(t => t.IdEndereco)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Navigation(p => p.Pedido)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.Endereco)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.ToTable("Entregas");
        }
    }
}
