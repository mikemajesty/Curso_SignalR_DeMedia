using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
namespace project_9
{
    [HubName("myConnection")]
    public class MyConnection : Hub
    {
        private static int _userCount = 0;

        public static ConcurrentDictionary<string, UserData> _user = new ConcurrentDictionary<string, UserData>();

        public override Task OnConnected()
        {
            Interlocked.Increment(ref _userCount);
            var user = new UserData
            {
                ACtive = true,
                Date = DateTime.Now,
                Name = Context.QueryString["myQueryString"]
            };
            _user[Context.ConnectionId] = user;
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Interlocked.Decrement(ref _userCount);
            _user[Context.ConnectionId] = null;
            return base.OnDisconnected(stopCalled);
        }
        
        public void InfoServer()
        {
            Clients.Caller.showAlertServer("info save in the server:\n user's count: " + _userCount + "\n name:" + _user[Context.ConnectionId].Name.ToString() +
                "\n date:" + _user[Context.ConnectionId].Date.ToString() + "\n Active: " + _user[Context.ConnectionId].ACtive.ToString());
        }


        public class MyMessage
        {
            public string Name { get; set; }
            public string Message { get; set; }
            public string Time { get; set; }
            public string Client { get; set; }

        }
        public void Connected(string txt)
        {
            Clients.All.ConnectedMessage(txt);
        }
        public class UserData
        {
            public bool ACtive { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }


        }
    }
}