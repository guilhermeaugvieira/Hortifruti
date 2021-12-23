using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HortifrutiBE.API.Configurations
{
    public static class HealthCheckConfiguration
    {
        public static IServiceCollection AddHealthCheckConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(
                    configuration.GetConnectionString("Development"),
                    name: "SqlDatabase",
                    tags: new string[] { "Database" }
                );                

            services.AddHealthChecksUI(setup => {
                setup.AddHealthCheckEndpoint("Local", "healthcheck");
                setup.MaximumHistoryEntriesPerEndpoint(50);
                setup.SetEvaluationTimeInSeconds(30);
            }).AddSqlServerStorage(configuration.GetConnectionString("Development"));

            return services;
        }

        public static IApplicationBuilder UseHealthCheckConfig(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/healthcheck", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options =>
            {
                options.AddCustomStylesheet("HealthCheck/healthCheckStyle.css");
                options.UIPath = "/healthcheck-ui";
            });

            return app;
        }
    }
}
