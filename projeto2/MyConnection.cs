using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
namespace projeto2
{
    public class MyConnection : PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            return Connection.Broadcast(data);
        }
    }
}