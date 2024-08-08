using API.Gate.GraphQl.Exceptions;
using DAL;
using Domain.ClienLogging;
using Domain.Core.Users;
using HotChocolate.Subscriptions;

namespace API.Gate.GraphQl.Mutations
{
    [ExtendObjectType("Mutations")]
    public class ClientLogsMutations
    {
        private readonly Context context;
        private readonly Repository<ClientLog> repository;

        public ClientLogsMutations([Service] Context context)
        {
            this.context = context;
            this.repository = new Repository<ClientLog>(context);
        }

        [UseSorting]
        [UseFiltering]
        public async Task<ClientLog> CreateClientLog(ClientLog clientLog,
                                                    [Service] ITopicEventSender sender)
        {
            await this.repository.CreateAsync(clientLog);
            return clientLog;
        }

        [UseSorting]
        [UseFiltering]
        public async Task<ClientLog> UpdateClientLog(ClientLog clientLog,
                                                    [Service] ITopicEventSender sender)
        {
            try
            {
                await this.repository.UpdateAsync(clientLog);
                return clientLog;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"ClientLog with id == {clientLog.Id} not found", clientLog.Id);
            }
            catch
            {
                throw;
            }
        }

        [UseFiltering]
        public async Task<ClientLog> RemoveClientLog(ClientLog clientLog,
                                                    [Service] ITopicEventSender sender)
        {
            try
            {
                await this.repository.DeleteAsync(clientLog.Id);
                return clientLog;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"ClientLog with id == {clientLog.Id} not found", clientLog.Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
