using MicroMessaging.BLL.Interfaces.Request;

namespace MicroMessaging.BLL.Interfaces.Managers
{
    public interface IRequestManager
    {
        Task<TResult> SendAsync<TResult>(IAppRequest<TResult> request);
    }
}
