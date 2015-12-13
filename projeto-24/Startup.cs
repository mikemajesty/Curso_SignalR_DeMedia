using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(projeto_24.Startup))]
namespace projeto_24
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}