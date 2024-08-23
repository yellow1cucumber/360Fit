using API.Gate.GraphQl.Exceptions;
using AutoMapper;
using DAL;
using Domain.ClienLogging;
using HotChocolate.Subscriptions;


namespace API.Gate.GraphQl.Mutations
{
    [ExtendObjectType("Mutations")]
    public class ClientLogsMutations
    {
        private readonly Context context;
        private readonly Repository<ClientLog> repository;

        private readonly IMapper mapper;

        public ClientLogsMutations([Service] Context context, IMapper mapper)
        {
            this.context = context;
            this.repository = new Repository<ClientLog>(context);
            this.mapper = mapper;
        }

        [UseSorting]
        [UseFiltering]
        public async Task<ClientLog> CreateClientLog(ClientLogDTO payload,
                                                    [Service] ITopicEventSender sender)
        {
            var clientLog = this.mapper.Map<ClientLog>(payload);
            await this.repository.CreateAsync(clientLog);
            return clientLog;
        }

        [UseSorting]
        [UseFiltering]
        public async Task<ClientLog> UpdateClientLog(ClientLogDTO payload,
                                                    [Service] ITopicEventSender sender)
        {
            var clientLog = this.mapper.Map<ClientLog>(payload);
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
        public async Task<ClientLog> RemoveClientLog(ClientLogDTO payload,
                                                    [Service] ITopicEventSender sender)
        {
            var clientLog = this.mapper.Map<ClientLog>(payload);
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
