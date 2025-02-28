using Microsoft.AspNetCore.SignalR;
using WebApiSignalR238.Services;

namespace WebApiSignalR238.Hubs
{
    public class MessageHub:Hub
    {
        private readonly IFileService _fileService;

        public MessageHub(IFileService fileService)
        {
            _fileService = fileService;
        }

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

        public async Task JoinRoom(string room,string user)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId,room);
           //// await Groups.RemoveFromGroupAsync(Context.ConnectionId, room);
            await Clients.OthersInGroup(room).SendAsync("ReceiveJoinInfo", user);
        }

        public async Task SendMessageRoom(string room,string user)
        {
            await Clients.OthersInGroup(room).SendAsync("ReceiveInfoRoom", user, await _fileService.Read(room));
        }
    }
}

