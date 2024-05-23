using MicroMessaging.DAL.Configuration;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MicroMessaging.DAL.Repositories.Implemintations.Base
{
    public abstract class BaseRepository
    {
        private readonly NpgsqlConnection sqlConnection;
        private NpgsqlCommand sqlCommand;

        public BaseRepository(IConfiguration configuration)
        {
            sqlConnection = new NpgsqlConnection(configuration.GetConnectionString(DbConfiguration.pgSqlConnectionString));
        }
      

        protected async Task Execute(string query, Func<NpgsqlCommand, Task> predicate, CancellationToken cancellationToken)
        {
            try
            {
                sqlCommand = new NpgsqlCommand(query);
                sqlCommand.Connection = sqlConnection;

                await sqlConnection.OpenAsync(cancellationToken);

                await predicate(sqlCommand);
            }
            catch
            {
                throw;
            }
            finally 
            {
                await sqlConnection.CloseAsync();
                await sqlCommand.DisposeAsync();
            }
        }

        protected async Task<TResult> Execute<TResult>(string query, Func<NpgsqlCommand, Task<TResult>> predicate, CancellationToken cancellationToken)
        {
            try
            {
                sqlCommand = new NpgsqlCommand(query);
                sqlCommand.Connection = sqlConnection;
                await sqlConnection.OpenAsync(cancellationToken);

                var resutt = await predicate(sqlCommand);                

                return resutt;
            }
            catch
            {
                throw;
            }
            finally
            {
                await sqlConnection.CloseAsync();
                await sqlCommand.DisposeAsync();
            }
        }
    }
}
