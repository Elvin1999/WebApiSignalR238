using Microsoft.AspNetCore.SignalR;

namespace WebApiSignalR238.Hubs
{
    public class MessageHub:Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Others.SendAsync("ReceiveConnectInfo", "User Connected");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.Others.SendAsync("ReceiveDisconnectInfo", "User Disconnected");
        }
    }
}
