using MicroMessaging.BLL.Interfaces.Request;

namespace MicroMessaging.BLL.Features.Message.Command.SendMessage
{
    public class SendMessageRequest : IAppRequest<SendMessageResponse>
    {
        public string Message { get; set; }
        public ulong MessageNumber { get; set; }
    }
}
