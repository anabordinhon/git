using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesteDoMercado.Startup))]
namespace TesteDoMercado
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
