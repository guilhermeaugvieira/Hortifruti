using System;
using System.Diagnostics;
using System.Text;
using HortifrutiBE.InfraStructure.Models;
using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using KissLog.Formatters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HortifrutiBE.InfraStructure.Configurations
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggerConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(context =>
            {
                return Logger.Factory.Get();
            });

            services.AddLogging(logging =>
            {
                logging.AddKissLog(options =>
                {
                    options.Formatter = (FormatterArgs args) =>
                    {
                        if (args.Exception == null)
                            return args.DefaultValue;

                        string exceptionStr = new ExceptionFormatter().Format(args.Exception, args.Logger);

                        return string.Join(Environment.NewLine, new[] { args.DefaultValue, exceptionStr });
                    };
                });
            });

            var loggerConfiguration = configuration.GetSection("KissLog");
            services.Configure<LoggerModel>(loggerConfiguration);

            return services;
        }

        public static IApplicationBuilder UseKissLog(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseKissLogMiddleware(options =>
            {
                ConfigureKissLog(options, configuration);
            });

            return app;
        }

        private static void ConfigureKissLog(IOptionsBuilder options, IConfiguration configuration)
        {
            options.Options.AppendExceptionDetails((ex) =>
            {
                StringBuilder sb = new StringBuilder();

                if (ex is NullReferenceException nullRefException)
                {
                    sb.AppendLine("Important: check for null references");
                }

                return sb.ToString();
            });

            // Logs internos do kiss log
            options.InternalLog = (message) =>
            {
                Debug.WriteLine(message);
            };

            // Registra as saidas de log
            RegisterKissLogListeners(options, configuration);
        }

        private static void RegisterKissLogListeners(IOptionsBuilder options, IConfiguration configuration)
        {
            var loggerSection = configuration.GetSection("KissLog");
            var loggerData = loggerSection.Get<LoggerModel>();


            options.Listeners.Add(
                new RequestLogsApiListener(
                    new Application(
                        loggerData.OrganizationId,
                        loggerData.ApplicationId
                        )
                    )
                {
                    ApiUrl = loggerData.ApiUrl
                }
            );
        }
    }
}
