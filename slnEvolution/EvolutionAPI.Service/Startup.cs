using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Reflection;
using EvolutionAPI.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using EvolutionAPI.Core.Interfaces.Aggregates;
using EvolutionAPI.Core.Aggregates;
using EvolutionAPI.Core.Interfacecs.Validation;
using EvolutionAPI.Core.Validation;
using EvolutionAPI.Core.Interfaces.Services;
using EvolutionAPI.Core.Services;
using EvolutionAPI.Core.Interfaces.Repository;
using EvolutionAPI.Infrastructure.Entity.Repository;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Serilog;
using Serilog.Formatting.Json;

namespace EvolutionAPI.Service
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                   .AddJsonOptions(options =>
                   {
                       options.SerializerSettings.Formatting = Formatting.Indented;
                   });

            services.AddSwaggerGen(
                c =>
                {
                    c.DescribeAllEnumsAsStrings();
                    c.OperationFilter<MultipleOperationsWithSameVerbFilter>();

                    c.SwaggerDoc("v1", new Info
                    {
                        Version = "v1",
                        Title = "Evolution API",
                        Description = "Evolution API",
                        TermsOfService = "None"
                    });

                    c.IncludeXmlComments(Path.ChangeExtension(Assembly.GetEntryAssembly().Location, "xml"));

                    c.DescribeAllEnumsAsStrings();
                });

            //ConfigureOriginacaoAdapter(services);

            ConfigureEvolutionAPI(services);

            if (Configuration.GetSection("ApplicationInsights").GetValue<bool>("Enabled"))
            {
                services.AddApplicationInsightsTelemetry(Configuration);
            }
        }

        private void ConfigureEvolutionAPI(IServiceCollection services)
        {
            services.AddDbContext<EvolutionContext>(
                options => options.UseSqlServer(Environment.GetEnvironmentVariable("SQLCONNSTR_EvolutionContext"),
                p => p.UseRowNumberForPaging()));

            services.AddScoped<IAggregateFactory, AggregateFactory>();
            services.AddScoped<IValidatorFactory, ValidatorFactory>();

            services.AddScoped<IEvolutionService, EvolutionService>();
            services.AddScoped<IEvolutionRepository, EvolutionRepository>();
        }

        private void ConfigureOriginacaoAdapter(IServiceCollection services)
        {
            //services.AddScoped<ICertificateClientSettings>(e => new CertificateClientSettings(Configuration.GetSection("ClientCertificate").GetValue<string>("Thumbprint"), false));
            //services.AddScoped<IHttpClientFactory, HttpClientFactory>();

            //services.AddScoped<IOriginacaoAdapter, OriginacaoAdapter>();
            //services.AddSingleton<IOriginacaoAdapterSettings>(new OriginacaoAdapterSettings(Environment.GetEnvironmentVariable("OriginacaoAPI")));

            //services.AddScoped<ICorrespondenteAdapter, CorrespondenteAdapter>();
            //services.AddSingleton<ICorrespondenteAdapterSettings>(new CorrespondenteAdapterSettings(Environment.GetEnvironmentVariable("CorrespondenteAPI")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

            app.UseMiddleware<RequestLocalizationMiddleware>();

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(new CultureInfo("pt-BR")),

            });

            ConfigurarLog(app, env, loggerFactory);

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Evolution API"));
        }

        private void ConfigurarLog(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var appname = this.GetType().FullName.Replace($".{this.GetType().Name}", "");

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Async(a => a.RollingFile($"logs/{appname}-{{Hour}}-{Environment.MachineName}.txt"))
                .WriteTo.Async(a => a.Console(new JsonFormatter()))
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", appname)
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            Serilog.Debugging.SelfLog.Enable(Console.Error);
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddDebug();
            }
        }
    }
}
