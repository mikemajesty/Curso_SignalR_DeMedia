using Microsoft.AspNet.SignalR;
using System.Threading;
using System.Threading.Tasks;
namespace projeto2
{
    public class MyConnection : PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            return Connection.Broadcast(data);
        }

        //------------------------------------------------------------------------------------//
        private static int QuantityConnection = 0;

        protected override Task OnConnected(IRequest request, string connectionId)
        {
            Interlocked.Increment(ref QuantityConnection);
            Connection.Broadcast($"Visitors:{QuantityConnection}");
            Connection.Send(connectionId,"Bem Vindo: "+ connectionId);
            return base.OnConnected(request,connectionId);
        }

        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            Interlocked.Decrement(ref QuantityConnection);
            Connection.Broadcast($"Visitors:{QuantityConnection}");
            return base.OnDisconnected(request, connectionId, stopCalled);
        }

    }
}