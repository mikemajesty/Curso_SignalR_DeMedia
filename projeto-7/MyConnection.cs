using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace projeto_7
{
    [HubName("myConnection")]
    public class MyConnection : Hub
    {
        public void MySend(string message) => Clients.All.sendMessage(message);

    }
}