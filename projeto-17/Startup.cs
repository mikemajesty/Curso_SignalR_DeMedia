using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(projeto_17.Startup))]

namespace projeto_17
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
