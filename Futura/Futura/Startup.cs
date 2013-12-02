using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Futura.Startup))]
namespace Futura
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
