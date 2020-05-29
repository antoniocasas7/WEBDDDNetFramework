using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDDDNet.Startup))]
namespace WebDDDNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
