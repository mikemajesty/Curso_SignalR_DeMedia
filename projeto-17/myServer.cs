using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
namespace projeto_17
{
    public class myServer : Hub
    {
        public void AlertAll(string menssage)
        {
            Clients.All.clientAlertAll(menssage);
        }
    }
}