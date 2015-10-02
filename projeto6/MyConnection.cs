using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
namespace projeto6
{
    internal class MyConnection : PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            return Connection.Broadcast(data);
            //return base.OnReceived(request, connectionId, data);
        }
         
    }
}