using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HortifrutiBE.Data.Migrations.Application
{
    public partial class Tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Rua = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CEP = table.Column<string>(type: "VARCHAR(9)", nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR(2)", nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    WhatsApp = table.Column<bool>(type: "BIT", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Sobrenome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdentityId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    IdTelefone = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Telefones_IdTelefone",
                        column: x => x.IdTelefone,
                        principalTable: "Telefones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hortifrutis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    IdEndereco = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProprietario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTelefone = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNPJ = table.Column<string>(type: "VARCHAR(14)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hortifrutis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hortifrutis_Enderecos_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hortifrutis_Telefones_IdTelefone",
                        column: x => x.IdTelefone,
                        principalTable: "Telefones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hortifrutis_Usuarios_IdProprietario",
                        column: x => x.IdProprietario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdComprador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_IdComprador",
                        column: x => x.IdComprador,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuario_Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEndereco = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Endereco_Enderecos_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_Endereco_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHortifruti = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    Detalhes = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Hortifrutis_IdHortifruti",
                        column: x => x.IdHortifruti,
                        principalTable: "Hortifrutis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Entregas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEndereco = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Envio = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Recebimento = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entregas_Enderecos_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entregas_Pedidos_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItensEstoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProduto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(6,2)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensEstoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensEstoque_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItensPedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdItemEstoque = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedido_ItensEstoque_IdItemEstoque",
                        column: x => x.IdItemEstoque,
                        principalTable: "ItensEstoque",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItensPedido_Pedidos_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_IdEndereco",
                table: "Entregas",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_IdPedido",
                table: "Entregas",
                column: "IdPedido",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hortifrutis_CNPJ",
                table: "Hortifrutis",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hortifrutis_IdEndereco",
                table: "Hortifrutis",
                column: "IdEndereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hortifrutis_IdProprietario",
                table: "Hortifrutis",
                column: "IdProprietario");

            migrationBuilder.CreateIndex(
                name: "IX_Hortifrutis_IdTelefone",
                table: "Hortifrutis",
                column: "IdTelefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensEstoque_IdProduto",
                table: "ItensEstoque",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_IdItemEstoque",
                table: "ItensPedido",
                column: "IdItemEstoque",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_IdPedido",
                table: "ItensPedido",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdComprador",
                table: "Pedidos",
                column: "IdComprador");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdHortifruti_Nome",
                table: "Produtos",
                columns: new[] { "IdHortifruti", "Nome" });

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_Numero",
                table: "Telefones",
                column: "Numero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Endereco_IdEndereco",
                table: "Usuario_Endereco",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Endereco_IdUsuario_IdEndereco",
                table: "Usuario_Endereco",
                columns: new[] { "IdUsuario", "IdEndereco" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CPF",
                table: "Usuarios",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdentityId",
                table: "Usuarios",
                column: "IdentityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTelefone",
                table: "Usuarios",
                column: "IdTelefone",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entregas");

            migrationBuilder.DropTable(
                name: "ItensPedido");

            migrationBuilder.DropTable(
                name: "Usuario_Endereco");

            migrationBuilder.DropTable(
                name: "ItensEstoque");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Hortifrutis");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Telefones");
        }
    }
}
