﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(projeto.Startup))]

namespace projeto
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<MyConnection>("/echo");  // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
