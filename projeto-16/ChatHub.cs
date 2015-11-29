using Microsoft.AspNet.SignalR;

namespace projeto_16
{
    public class ChatHub : Hub
    {
        public void sendMeddageToAll(string message)
        {
            Clients.All.sendMeddageToAll(message);
            Clients.Caller.alertCaller("Your mesaage was sent.");
        }
    }
}