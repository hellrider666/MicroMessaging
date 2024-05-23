using MicroMessaging.BLL.Mapping.DTOs;

namespace MicroMessaging.BLL.Features.Message.Queries.GetLastMessages
{
    public class GetLastMessagesResponse
    {
        public List<MessageDTO> Messages { get; set; }
    }
}
