using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pollia.Startup))]
namespace Pollia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //var configuration = WebApiConfiguration.HttpConfiguration;
            //app.Map("/api", inner =>
            //{
            //    inner.UseWebApi(configuration);
            //});
        }
    }
}
