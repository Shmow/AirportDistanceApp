using AirportDistance.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nancy;
using Nancy.TinyIoc;

namespace AirportDistance.Api
{
    public class CustomNancyBootstrapper : DefaultNancyBootstrapper
    {
        private readonly IApplicationBuilder _app;
        private readonly IHostingEnvironment _env;

        public CustomNancyBootstrapper(IApplicationBuilder app)
        {
            _app = app;
        }

        public CustomNancyBootstrapper(IApplicationBuilder app, IHostingEnvironment env) : this(app)
        {
            _env = env;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register(_app.ApplicationServices.GetService<IOptions<AppConfig>>());
        }
    }
}