namespace MicroMessaging.BLL.Features.Message.Command.SendMessage
{
    public class SendMessageResponse
    {
        public string Message { get; set; }
        public ulong MessageNumber { get; set; }
        public DateTime MessageDateTime { get; set; }
    }
}
