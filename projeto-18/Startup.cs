using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(projeto_18.Startup))]
namespace projeto_18
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
