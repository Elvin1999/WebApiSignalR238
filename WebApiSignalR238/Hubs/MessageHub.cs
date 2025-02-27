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

        public async Task SendMessage(string message,double data)
        {
            await Clients.All.SendAsync("ReceiveMessage", message + "'s Offer is ", data);
        }
    }
}
