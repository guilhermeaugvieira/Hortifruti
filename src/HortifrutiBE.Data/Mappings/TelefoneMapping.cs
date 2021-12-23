using HortifrutiBE.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortifrutiBE.Data.Mappings
{
    public class TelefoneMapping : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Numero)
                .HasColumnType("VARCHAR(20)")
                .IsRequired();

            builder.Property(p => p.WhatsApp)
                .HasColumnType("BIT")
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(p => p.UltimaAtualizacao)
                .HasColumnType("DATETIME");

            builder.HasIndex(p => p.Numero).IsUnique();

            builder.Navigation(p => p.Usuario)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.Hortifruti)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.ToTable("Telefones");
        }
    }
}
