using MediatR;
using MicroMessaging.BLL.Interfaces.Managers;
using MicroMessaging.BLL.Interfaces.Request;

namespace MicroMessaging.BLL.Managers
{
    public class RequestManager : IRequestManager
    {
        private readonly IMediator _mediator;

        public RequestManager(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<TResult> SendAsync<TResult>(IAppRequest<TResult> request)
        {
            return await _mediator.Send(request);
        }
    }
}
