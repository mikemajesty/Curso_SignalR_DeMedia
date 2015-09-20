using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace projeto
{
    internal class MyConnection : PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            int contador = 0;

            if ((contador = data.IndexOf(":")) > -1)
            {
                var groupName = data.Substring(0, contador);
                var messageOrCommand = data.Substring(contador + 1);

                switch (messageOrCommand)
                {
                    case "join":
                        Groups.Add(connectionId, groupName);
                        Groups.Send(groupName,connectionId+" join in group "+ groupName);
                        break;
                    case "leave":
                        Groups.Remove(connectionId, groupName);
                        Groups.Send(groupName, connectionId + " leave the group " + groupName);
                        break;
                    default:
                        Groups.Send(groupName,messageOrCommand+"("+groupName+")");
                        break;
                }
            }
            else
            {
                Connection.Broadcast(data);
            }
            return base.OnReceived(request, connectionId, data);
        }
    }
}