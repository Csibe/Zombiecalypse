using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zombiecalypse.Startup))]
namespace Zombiecalypse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
