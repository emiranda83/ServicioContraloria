using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Contraloria.Startup))]
namespace Contraloria
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
