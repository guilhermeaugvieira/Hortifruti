using HortifrutiBE.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortifrutiBE.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Cidade)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(p => p.Bairro)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(p => p.Rua)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(p => p.CEP)
                .HasColumnType("VARCHAR(9)")
                .IsRequired();
            
            builder.Property(p => p.Estado)
                .HasColumnType("VARCHAR(2)")
                .IsRequired();

            builder.Property(p => p.Numero)
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(p => p.UltimaAtualizacao)
                .HasColumnType("DATETIME");

            builder.Navigation(p => p.Usuarios)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.Entregas)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.Hortifruti)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.ToTable("Enderecos");
        }
    }
}
