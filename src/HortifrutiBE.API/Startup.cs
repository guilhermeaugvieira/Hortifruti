using HortifrutiBE.API.Configurations;
using HortifrutiBE.API.Extensions;
using HortifrutiBE.Application.AutoMapper;
using HortifrutiBE.Data.Context;
using HortifrutiBE.InfraStructure.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HortifrutiBE.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfiguration(Configuration);

            services.AddDbContext<ApplicationContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("Development")).EnableSensitiveDataLogging();
            });

            services.AddSwaggerConfig();

            services.AddControllers();

            services.WebApiConfig();

            services.AddAutoMapper(typeof(UsuarioProfile));

            services.AddLoggerConfig(Configuration);

            services.AddJwtConfig(Configuration);

            services.AddHealthCheckConfiguration(Configuration);

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.ResolveDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerConfig(provider);
            }

            app.UseHealthCheckConfig();

            app.UseKissLog(Configuration);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseWebApiConfig();

            app.UseMiddleware<ExceptionMiddleware>();

        }
    }
}
