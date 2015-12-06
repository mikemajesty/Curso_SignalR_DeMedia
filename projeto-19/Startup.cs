using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(projeto_19.Startup))]
namespace projeto_19
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<ConnectionSpy>("/spy");
            app.Use<Spy>();

        }
    }
}
