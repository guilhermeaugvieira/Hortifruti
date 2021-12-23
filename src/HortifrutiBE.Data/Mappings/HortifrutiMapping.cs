using HortifrutiBE.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortifrutiBE.Data.Mappings
{
    public class HortifrutiMapping : IEntityTypeConfiguration<Hortifruti>
    {
        public void Configure(EntityTypeBuilder<Hortifruti> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(p => p.CNPJ)
                .HasColumnType("VARCHAR(14)")
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(p => p.UltimaAtualizacao)
                .HasColumnType("DATETIME");

            builder.HasOne(t => t.Proprietario)
                .WithMany(t => t.Hortifrutis)
                .HasForeignKey(t => t.IdProprietario)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(t => t.Endereco)
                .WithOne(t => t.Hortifruti)
                .HasForeignKey<Hortifruti>(t => t.IdEndereco)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(t => t.Telefone)
                .WithOne(t => t.Hortifruti)
                .HasForeignKey<Hortifruti>(t => t.IdTelefone)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasIndex(p => p.CNPJ).IsUnique();

            builder.Navigation(p => p.Endereco)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.Proprietario)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.Telefone)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.Produtos)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.ToTable("Hortifrutis");
        }
    }
}
