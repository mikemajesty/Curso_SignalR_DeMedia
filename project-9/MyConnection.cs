using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_9
{
    [HubName("myConnection")]
    public class MyConnection : Hub
    {        

        public void MySend(MyMessage msg) => Clients.All.sendMessage(msg.Name, msg.Message, msg.Time);
        public void alertAll(string name,string connectionID)
        {
            Clients.AllExcept(connectionID).showAlertAll(name);
        }


        public class MyMessage
        {
            public string Name { get; set; }
            public string Message { get; set; }
            public string Time { get; set; }


        }
    }
}