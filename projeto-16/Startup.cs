using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(projeto_16.Startup))]

namespace projeto_16
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR("/myApp",new Microsoft.AspNet.SignalR.HubConfiguration());
        }
    }
}
