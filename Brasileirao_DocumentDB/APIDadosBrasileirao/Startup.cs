using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace APIDadosBrasileirao
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
            var documentDBConfigurations = new DocumentDBConfigurations();
            new ConfigureFromConfigurationOptions<DocumentDBConfigurations>(
                Configuration.GetSection("DocumentDBConfigurations"))
                    .Configure(documentDBConfigurations);
            services.AddSingleton<DocumentDBConfigurations>(
                documentDBConfigurations);

            services.AddMvc();

            // Ativando o Application Insights
            services.AddApplicationInsightsTelemetry(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}