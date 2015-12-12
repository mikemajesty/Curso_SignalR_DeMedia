using System.Diagnostics;
using System.ServiceProcess;

using Microsoft.AspNet.SignalR;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;

[assembly: OwinStartup(typeof(projeto_23.Startup))]
namespace projeto_23
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (!EventLog.SourceExists("SignalRChat"))
            {
                EventLog.CreateEventSource("SignalRChat", "Application");
            }
            eventLog1.Source = "SignalRChat";
            eventLog1.Log = "Application";

            eventLog1.WriteEntry("In OnStart");
            string url = "http://localhost:8080";
            WebApp.Start(url);
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop");
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }

    }
    public class MyHub: Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
    }
}
