using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jokes3.Startup))]
namespace jokes3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
