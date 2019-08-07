using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Capa.Presentacion.Startup))]
namespace Capa.Presentacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
