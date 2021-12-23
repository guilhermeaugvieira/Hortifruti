using HortifrutiBE.Business.Entities;
using HortifrutiBE.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace HortifrutiBE.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<ItemEstoque> ItensEstoque { get; set; }
        public DbSet<Hortifruti> Hortifrutis { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioEndereco> Usuario_Endereco { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EnderecoMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemEstoqueMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HortifrutiMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidoMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntregaMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TelefoneMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioEnderecoMapping).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemPedidoMapping).Assembly);
        }
    }
}
