using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRPlusEncodingTest.Hubs
{
    public abstract class HubBase : Hub
    {
        public override Task OnConnected()
        {
            Connected();
            return Clients.All.joined(Context.ConnectionId, DateTime.UtcNow);

        }

        public override Task OnDisconnected()
        {
            Disconnected();
            return Clients.All.leave(Context.ConnectionId, DateTime.UtcNow);
        }

        public override Task OnReconnected()
        {
            Reconnected();
            return Clients.All.rejoined(Context.ConnectionId, DateTime.UtcNow);
        }

        public abstract void Connected();
        public abstract void Disconnected();
        public abstract void Reconnected();
    }
}