using MicroMessaging.BLL.Features.Message.Queries.GetLastMessageNumber;
using MicroMessaging.BLL.Interfaces.Managers;
using MicroMessaging.CommonsHelper.Helpers.Logging;
using MicroMessaging.CommonsHelper.Helpers.Serialization.Json;
using Microsoft.AspNetCore.SignalR;

namespace MicroMessaging.WebServer.Hubs
{
    public class MessageHub : Hub
    {
        private readonly ILogger<MessageHub> _logger;

        private readonly IRequestManager _requestManager;
        public MessageHub(ILogger<MessageHub> logger, IRequestManager requestManager)
        {
            _logger = logger;

            _requestManager = requestManager;
        }

        public override async Task OnConnectedAsync()
        {
            var lastMessageNumber = await _requestManager.SendAsync(new GetLastMessageNumberRequest());

            await Clients.All.SendAsync("ReceiveLastMessageNumber", lastMessageNumber.ToJson());


            await Task.Run(() => 
            { 
                _logger.Info($"{Context.ConnectionId} has joined");
                _logger.Info($"Last Message Number response = {lastMessageNumber.ToJson()}");
            });
        }
    }
}
