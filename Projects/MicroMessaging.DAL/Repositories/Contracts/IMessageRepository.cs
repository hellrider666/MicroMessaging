using MicroMessaging.DAL.Entities;

namespace MicroMessaging.DAL.Repositories.Contracts
{
    public interface IMessageRepository
    {
        Task SendMessageAsync(ulong messageNumber, string messageStr, DateTime messageDateTime, CancellationToken cancellationToken);
        Task<List<MessageEntity>> GetLastMessagesAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
        Task<long?> GetLastMessageNumberAsync(CancellationToken cancellationToken);
        Task<MessageEntity?> GetMessageByNumberAsync(ulong messageNumber, CancellationToken cancellationToken);
    }
}
