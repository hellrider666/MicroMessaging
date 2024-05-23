using MicroMessaging.BLL.Interfaces.Request;

namespace MicroMessaging.BLL.Features.Message.Queries.GetLastMessages
{
    public class GetLastMessagesRequest : IAppRequest<GetLastMessagesResponse>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
