using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace projeto_18
{
    public class Board : Hub
    {
        private const int BoardWidth = 250;
        private const int BoardHeight = 250;
        private static int[,] _buffer = GetEmptyBuffer();
        public Task BroadCastPoint(int x, int y)
        {
            if (x < 0) x = 0;
            if (x >= BoardWidth) x = BoardWidth - 1;
            if (y < 0) y = 0;
            if (y >= BoardHeight) y = BoardHeight - 1;
            int color = 0;
            int.TryParse(Clients.Caller.color, out color);
            _buffer[x, y] = color;
            return Clients.Others.DrawPoint(x,y, Clients.Caller.color);
        }
        public Task BroadCastClear()
        {
            _buffer = GetEmptyBuffer();
            return Clients.Others.Clear();
        }
        private static int[,] GetEmptyBuffer()
        {
            var buffer = new int[BoardWidth, BoardHeight];
            return buffer;
        }
        public override Task OnConnected()
        {
            return Clients.Caller.Update(_buffer);
        }
    }
}