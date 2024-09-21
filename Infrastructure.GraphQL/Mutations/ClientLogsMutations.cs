using AutoMapper;
using Domain.ClienLogging;
using HotChocolate.Subscriptions;

using Infrastructure.GraphQL.Exceptions;
using Infrastructure.GraphQL.Attributes;

#region TYPEDEF
using Logs = DAL.Repository<Domain.ClienLogging.ClientLog>;
#endregion


namespace Infrastructure.GraphQL.Mutations
{
    [GQLMutation]
    [ExtendObjectType("Mutations")]
    public class ClientLogsMutations
    {
        private readonly IMapper mapper;

        public ClientLogsMutations(IMapper mapper)
            => this.mapper = mapper;

        [UseSorting]
        [UseFiltering]
        public async Task<ClientLog> CreateClientLog(ClientLogDTO payload,
                                                    [Service] ITopicEventSender sender,
                                                    [Service] Logs logs)
        {
            var clientLog = mapper.Map<ClientLog>(payload);
            await logs.CreateAsync(clientLog);
            return clientLog;
        }

        [UseSorting]
        [UseFiltering]
        public async Task<ClientLog> UpdateClientLog(ClientLogDTO payload,
                                                    [Service] ITopicEventSender sender,
                                                    [Service] Logs logs)
        {
            var clientLog = mapper.Map<ClientLog>(payload);
            try
            {
                await logs.UpdateAsync(clientLog);
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
        public async Task<ClientLog> RemoveClientLog(ClientLogDTO payload,
                                                    [Service] ITopicEventSender sender,
                                                    [Service] Logs logs)
        {
            var clientLog = mapper.Map<ClientLog>(payload);
            try
            {
                await logs.DeleteAsync(clientLog.Id);
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
