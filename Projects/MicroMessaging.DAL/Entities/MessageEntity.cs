using MicroMessaging.DAL.Entities.Base;

namespace MicroMessaging.DAL.Entities
{
    public class MessageEntity : BaseEntity
    {
        public string MessageStr { get; set; } 
        public long MessageNumber { get; set; }
        public DateTime MessageDateTime { get; set; }
    }
}
