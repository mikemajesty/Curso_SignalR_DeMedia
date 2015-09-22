using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(projeto4.Startup))]

namespace projeto4
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
        }
    }
}
