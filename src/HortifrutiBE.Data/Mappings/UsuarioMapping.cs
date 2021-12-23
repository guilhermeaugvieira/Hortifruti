using HortifrutiBE.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortifrutiBE.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IdentityId)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(p => p.Sobrenome)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(p => p.CPF)
                .HasColumnType("VARCHAR(11)")
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(p => p.UltimaAtualizacao)
                .HasColumnType("DATETIME");

            builder.HasOne(t => t.Telefone)
                .WithOne(t => t.Usuario)
                .HasForeignKey<Usuario>(t => t.IdTelefone)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => p.IdentityId).IsUnique();

            builder.HasIndex(p => p.CPF).IsUnique();

            builder.Navigation(p => p.Enderecos)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.Telefone)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.Hortifrutis)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.Pedidos)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.ToTable("Usuarios");
        }
    }
}
