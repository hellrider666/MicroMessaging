using MicroMessaging.BLL.Features.Message.Command.SendMessage;
using MicroMessaging.BLL.Features.Message.Queries.GetLastMessages;
using MicroMessaging.BLL.Interfaces.Managers;
using MicroMessaging.WebServer.Controllers.Base;
using MicroMessaging.WebServer.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Net;

namespace MicroMessaging.WebServer.Controllers
{
    public class MessageController : BaseApiController
    {
        public MessageController(IRequestManager reqeustManager, IHubContext<MessageHub> messageHub, ILogger<MessageController> logger) 
            : base(reqeustManager, messageHub, logger) { }

        [HttpPost("SendMessage"), ProducesResponseType(typeof(SendMessageResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SendMessage(SendMessageRequest request)
        {
            return Ok(await ExecuteWithHubAsync(request));
        }

        [HttpGet("GetLastMessages"), ProducesResponseType(typeof(GetLastMessagesResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLastMessages([FromQuery] GetLastMessagesRequest request)
        {
            return Ok(await ExecuteRequestAsync(request));
        }
    }
}
