using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(projeto_15.Startup))]

namespace projeto_15
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR("/myApp",new Microsoft.AspNet.SignalR.HubConfiguration());
        }
    }
}
