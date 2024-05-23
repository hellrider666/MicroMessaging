using MicroMessaging.BLL.Interfaces.Managers;
using MicroMessaging.BLL.Interfaces.Request;
using MicroMessaging.CommonsHelper.Helpers.Logging;
using MicroMessaging.CommonsHelper.Helpers.Serialization.Json;
using MicroMessaging.WebServer.Hubs;
using MicroMessaging.WebServer.Validation.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Net;

namespace MicroMessaging.WebServer.Controllers.Base
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ProducesErrorResponseType(typeof(ValidationResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
    public class BaseApiController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _messageHub;
        private readonly IRequestManager _reqeustManager;
        private readonly ILogger<BaseApiController> _logger;

        public BaseApiController(IRequestManager reqeustManager, IHubContext<MessageHub> messageHub, ILogger<BaseApiController> logger)
        {
            _reqeustManager = reqeustManager;

            _messageHub = messageHub;

            _logger = logger;
        }

        protected async Task<TResponse> ExecuteRequestAsync<TResponse>(IAppRequest<TResponse> request)
        {
            var response = await _reqeustManager.SendAsync(request);

            return response;
        }

        protected async Task<TResponse> ExecuteWithHubAsync<TResponse>(IAppRequest<TResponse> request)
        {
            var response = await ExecuteRequestAsync(request);            

            await _messageHub.Clients.All.SendAsync("Receive", response.ToJson());

            _logger.Info($"Message broadcast: {response.ToJson()}");

            return response;
        }
    }
}
