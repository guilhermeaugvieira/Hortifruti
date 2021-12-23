using HortifrutiBE.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortifrutiBE.Data.Mappings
{
    public class UsuarioEnderecoMapping : IEntityTypeConfiguration<UsuarioEndereco>
    {
        public void Configure(EntityTypeBuilder<UsuarioEndereco> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataCadastro)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(p => p.UltimaAtualizacao)
                .HasColumnType("DATETIME");

            builder.HasOne(t => t.Usuario)
                .WithMany(t => t.Enderecos)
                .HasForeignKey(t => t.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(t => t.Endereco)
                .WithMany(t => t.Usuarios)
                .HasForeignKey(t => t.IdEndereco)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasIndex(p => new { p.IdUsuario, p.IdEndereco }).IsUnique();

            builder.Navigation(p => p.Usuario)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.Endereco)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.ToTable("Usuario_Endereco");
        }
    }
}
