using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(projeto2.Startup))]
namespace projeto2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
