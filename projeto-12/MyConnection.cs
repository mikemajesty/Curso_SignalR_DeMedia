using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Threading.Tasks;

namespace project_9
{
    [HubName("myConnection")]
    public class MyConnection : Hub
    {
        public override Task OnConnected()
        {
            return Clients.All.showConnected();
            //return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return Clients.All.showDisconected();
            //return base.OnDisconnected(stopCalled);
        }
        public void MySend(MyMessage msg)
        {

            if (String.IsNullOrEmpty(msg.Client))
            {
                //Clients.All.sendMessage(msg.Name, msg.Message, msg.Time);
                Clients.Others.sendMessage(msg.Name, msg.Message, msg.Time);
                Clients.Caller.sendMsg("Your message was sent.");
            }
            else
            {
                Clients.Client(msg.Client).clientMessage(msg.Name, msg.Message, msg.Time);
                Clients.Caller.sendMsg("Your message was sent.");
            }
        }
        public void InfoCtx()
        {
            Clients.Caller.showAlertYou(Context.ConnectionId + "\n" + Context.Request.Headers + "\n" + Context.User + "\n" + Context.RequestCookies + "\n" + Context.QueryString["myQS"] + "\n" + Context.Request);
        }
        public void Join(string name)
        {
            Groups.Add(Context.ConnectionId, "VIP");
            Clients.Group("VIP").groupMsg(name + " join in VIP group");
        }
        public void Leave(string name)
        {
            Groups.Remove(Context.ConnectionId, "VIP");
            Clients.Group("VIP").groupMsg(name+" leave VIP group");
        }
        public void alertAll(string name)
        {
            Clients.AllExcept(Context.ConnectionId).showAlertAll(name);
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
    }
}