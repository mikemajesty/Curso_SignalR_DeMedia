using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
[assembly: OwinStartup(typeof(projeto_22.Startup))]
namespace projeto_22
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running  on {0}", url);
                Console.ReadKey();
            }
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
    public class MuHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name,message);
        }
    }
}
