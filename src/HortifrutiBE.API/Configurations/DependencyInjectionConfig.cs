using HortifrutiBE.Application.Extensions;
using HortifrutiBE.Application.Interfaces;
using HortifrutiBE.Application.Services;
using HortifrutiBE.Business.Interfaces;
using HortifrutiBE.Business.Notificacoes;
using HortifrutiBE.Business.Services.Base;
using HortifrutiBE.Data.Interfaces;
using HortifrutiBE.Data.Interfaces.Base;
using HortifrutiBE.Data.Repositories;
using HortifrutiBE.Data.Repositories.Base;
using HortifrutiBE.InfraStructure.Interfaces;
using HortifrutiBE.InfraStructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HortifrutiBE.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            #region Recursos da Aplicação
                services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
                services.AddScoped<IJwtService, JwtService>();
                services.AddScoped<INotificador, Notificador>();
                services.AddScoped<IUser, AspNetUser>();
            #endregion

            #region Serviços Da Aplicação
                services.AddScoped<IAcessoApplicationService, AcessoApplicationService>();
                services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();
                services.AddScoped<IHortifrutiApplicationService, HortifrutiApplicationService>();
                services.AddScoped<IProdutoApplicationService, ProdutoApplicationService>();
                services.AddScoped<IItemEstoqueApplicationService, ItemEstoqueApplicationService>();
                services.AddScoped<IPedidoApplicationService, PedidoApplicationService>();
                services.AddScoped<IEntregaApplicationService, EntregaApplicationService>();
            #endregion
            
            #region Serviços de Domínio
                services.AddScoped<IDomainBaseService, DomainBaseService>();
            #endregion

            #region Repositórios
                services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
                services.AddScoped<IEnderecoRepository, EnderecoRepository>();
                services.AddScoped<IEntregaRepository, EntregaRepository>();
                services.AddScoped<IHortifrutiRepository, HortifrutiRepository>();
                services.AddScoped<IItemEstoqueRepository, ItemEstoqueRepository>();
                services.AddScoped<IPedidoRepository, PedidoRepository>();
                services.AddScoped<IProdutoRepository, ProdutoRepository>();
                services.AddScoped<ITelefoneRepository, TelefoneRepository>();
                services.AddScoped<IUsuarioEnderecoRepository, UsuarioEnderecoRepository>();
                services.AddScoped<IUsuarioRepository, UsuarioRepository>();
                services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();
            #endregion

            return services;
        }


    }
}
