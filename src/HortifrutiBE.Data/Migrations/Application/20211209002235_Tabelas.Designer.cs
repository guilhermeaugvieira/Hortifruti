// <auto-generated />
using System;
using HortifrutiBE.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HortifrutiBE.Data.Migrations.Application
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211209002235_Tabelas")]
    partial class Tabelas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("VARCHAR(9)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("VARCHAR(2)");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime?>("UltimaAtualizacao")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Entrega", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("Envio")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("IdEndereco")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPedido")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Recebimento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime?>("UltimaAtualizacao")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco");

                    b.HasIndex("IdPedido")
                        .IsUnique();

                    b.ToTable("Entregas");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Hortifruti", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("VARCHAR(14)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("IdEndereco")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProprietario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdTelefone")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime?>("UltimaAtualizacao")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.HasIndex("IdEndereco")
                        .IsUnique();

                    b.HasIndex("IdProprietario");

                    b.HasIndex("IdTelefone")
                        .IsUnique();

                    b.ToTable("Hortifrutis");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.ItemEstoque", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("IdProduto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UltimaAtualizacao")
                        .HasColumnType("DATETIME");

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(6,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.ToTable("ItensEstoque");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.ItemPedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("IdItemEstoque")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPedido")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UltimaAtualizacao")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("IdItemEstoque")
                        .IsUnique();

                    b.HasIndex("IdPedido");

                    b.ToTable("ItensPedido");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("IdComprador")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UltimaAtualizacao")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("IdComprador");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Detalhes")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("IdHortifruti")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime?>("UltimaAtualizacao")
                        .HasColumnType("DATETIME");

                    b.Property<string>("UnidadeMedida")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)");

                    b.HasKey("Id");

                    b.HasIndex("IdHortifruti", "Nome");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Telefone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<DateTime?>("UltimaAtualizacao")
                        .HasColumnType("DATETIME");

                    b.Property<bool>("WhatsApp")
                        .HasColumnType("BIT");

                    b.HasKey("Id");

                    b.HasIndex("Numero")
                        .IsUnique();

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("IdTelefone")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdentityId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime?>("UltimaAtualizacao")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("IdTelefone")
                        .IsUnique();

                    b.HasIndex("IdentityId")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.UsuarioEndereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("IdEndereco")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UltimaAtualizacao")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco");

                    b.HasIndex("IdUsuario", "IdEndereco")
                        .IsUnique();

                    b.ToTable("Usuario_Endereco");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Entrega", b =>
                {
                    b.HasOne("HortifrutiBE.Business.Entities.Endereco", "Endereco")
                        .WithMany("Entregas")
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HortifrutiBE.Business.Entities.Pedido", "Pedido")
                        .WithOne("Entrega")
                        .HasForeignKey("HortifrutiBE.Business.Entities.Entrega", "IdPedido")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Hortifruti", b =>
                {
                    b.HasOne("HortifrutiBE.Business.Entities.Endereco", "Endereco")
                        .WithOne("Hortifruti")
                        .HasForeignKey("HortifrutiBE.Business.Entities.Hortifruti", "IdEndereco")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HortifrutiBE.Business.Entities.Usuario", "Proprietario")
                        .WithMany("Hortifrutis")
                        .HasForeignKey("IdProprietario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HortifrutiBE.Business.Entities.Telefone", "Telefone")
                        .WithOne("Hortifruti")
                        .HasForeignKey("HortifrutiBE.Business.Entities.Hortifruti", "IdTelefone")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Proprietario");

                    b.Navigation("Telefone");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.ItemEstoque", b =>
                {
                    b.HasOne("HortifrutiBE.Business.Entities.Produto", "Produto")
                        .WithMany("ItensEstoque")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.ItemPedido", b =>
                {
                    b.HasOne("HortifrutiBE.Business.Entities.ItemEstoque", "ItemEstoque")
                        .WithOne("ItemPedido")
                        .HasForeignKey("HortifrutiBE.Business.Entities.ItemPedido", "IdItemEstoque")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HortifrutiBE.Business.Entities.Pedido", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ItemEstoque");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Pedido", b =>
                {
                    b.HasOne("HortifrutiBE.Business.Entities.Usuario", "Comprador")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdComprador")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Comprador");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Produto", b =>
                {
                    b.HasOne("HortifrutiBE.Business.Entities.Hortifruti", "Hortifruti")
                        .WithMany("Produtos")
                        .HasForeignKey("IdHortifruti")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Hortifruti");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Usuario", b =>
                {
                    b.HasOne("HortifrutiBE.Business.Entities.Telefone", "Telefone")
                        .WithOne("Usuario")
                        .HasForeignKey("HortifrutiBE.Business.Entities.Usuario", "IdTelefone")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Telefone");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.UsuarioEndereco", b =>
                {
                    b.HasOne("HortifrutiBE.Business.Entities.Endereco", "Endereco")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HortifrutiBE.Business.Entities.Usuario", "Usuario")
                        .WithMany("Enderecos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Endereco", b =>
                {
                    b.Navigation("Entregas");

                    b.Navigation("Hortifruti");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Hortifruti", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.ItemEstoque", b =>
                {
                    b.Navigation("ItemPedido");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Pedido", b =>
                {
                    b.Navigation("Entrega");

                    b.Navigation("ItensPedido");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Produto", b =>
                {
                    b.Navigation("ItensEstoque");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Telefone", b =>
                {
                    b.Navigation("Hortifruti");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("HortifrutiBE.Business.Entities.Usuario", b =>
                {
                    b.Navigation("Enderecos");

                    b.Navigation("Hortifrutis");

                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
