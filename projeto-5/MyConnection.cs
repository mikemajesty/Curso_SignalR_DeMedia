using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace projeto_5
{
    public class MyConnection : PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            var message = JsonConvert.DeserializeObject<dynamic>(data);
            string strOut = "";
            if (message.Type == 1)
            {
                strOut = $"Message From:{message.From}:{message.Text}";
            }
            Connection.Broadcast(strOut = String.IsNullOrEmpty(strOut) ? "It's necessaty type a text": strOut);

            return base.OnReceived(request, connectionId, strOut);
        }
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            return base.OnConnected(request, connectionId);
        }
    }
}