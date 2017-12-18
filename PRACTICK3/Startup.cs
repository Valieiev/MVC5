using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PRACTICK3.Startup))]
namespace PRACTICK3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
