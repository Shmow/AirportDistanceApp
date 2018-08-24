using AirportDistance.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nancy.Bootstrapper;
using Nancy.Configuration;
using Nancy.Owin;

namespace AirportDistance.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppConfig>(Configuration.GetSection("settings"));

            services.AddTransient<IExternalService, ExternalService>();
            services.AddTransient<ICalculationService, CalculationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseOwin(x => x.UseNancy(new NancyOptions()
                                        {
                                            Bootstrapper = new CustomNancyBootstrapper(app, env)
                                        }));
        }
    }
}