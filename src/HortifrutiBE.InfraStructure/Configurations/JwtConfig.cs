using HortifrutiBE.InfraStructure.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HortifrutiBE.InfraStructure.Configurations
{
    public static class JwtConfig
    {
        public static IServiceCollection AddJwtConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var configuracoesJwt = configuration.GetSection("JwtSettings");
            services.Configure<JwtModel>(configuracoesJwt);

            return services;
        }
    }
}
