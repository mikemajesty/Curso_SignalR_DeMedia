using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(project_9.Startup))]

namespace project_9
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
