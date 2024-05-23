using MediatR;

namespace MicroMessaging.BLL.Interfaces.Request
{
    public interface IAppRequest<T> : IRequest<T> { }
}
