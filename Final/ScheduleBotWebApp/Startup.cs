using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScheduleBotWebApp.Startup))]
namespace ScheduleBotWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
