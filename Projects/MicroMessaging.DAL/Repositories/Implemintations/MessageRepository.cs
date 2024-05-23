using MicroMessaging.DAL.Entities;
using MicroMessaging.DAL.Repositories.Contracts;
using MicroMessaging.DAL.Repositories.Implemintations.Base;
using MicroMessaging.DAL.Helpers.Mapping;
using Microsoft.Extensions.Configuration;
using MicroMessaging.CommonsHelper.Helpers.Objects.CommonObjects;

namespace MicroMessaging.DAL.Repositories.Implemintations
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(IConfiguration configuration) : base(configuration) { }


        public async Task SendMessageAsync(ulong messageNumber, string messageStr, DateTime messageDateTime, CancellationToken cancellationToken)
        {
            await Execute($"INSERT INTO \"Messages\" (\"MessageStr\", \"MessageNumber\", \"MessageDateTime\") VALUES (N'{messageStr}', {messageNumber}, '{messageDateTime.ToEUFormatDateTimeToString()}')",
                x => x.ExecuteNonQueryAsync(cancellationToken), cancellationToken);
        }            

        public async Task<List<MessageEntity>> GetLastMessagesAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        {
            return await Execute($"SELECT * FROM \"Messages\" WHERE \"MessageDateTime\" BETWEEN '{startDate.ToEUFormatDateTimeToString()}' AND '{endDate.ToEUFormatDateTimeToString()}'", async x =>
            {
                var dataReader = await x.ExecuteReaderAsync(cancellationToken);

                return dataReader.MapToList<MessageEntity>();
            }, cancellationToken);
        }

        public async Task<long?> GetLastMessageNumberAsync(CancellationToken cancellationToken)
        {
            return await Execute($"SELECT \"MessageNumber\" FROM \"Messages\" ORDER BY \"Id\" DESC LIMIT '1'", async x =>
            {
                return (long?)await x.ExecuteScalarAsync(cancellationToken);
            }, cancellationToken);

        }

        public async Task<MessageEntity?> GetMessageByNumberAsync(ulong messageNumber, CancellationToken cancellationToken)
        {
            return await Execute($"SELECT * FROM \"Messages\" WHERE \"MessageNumber\" == '{messageNumber}'", async x =>
            {
                return (MessageEntity?)await x.ExecuteScalarAsync(cancellationToken);
            }, cancellationToken);
        }
    }
}
