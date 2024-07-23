using API.Gate.GraphQl.Exceptions;
using API.Gate.GraphQl.Subscriptions;
using DAL;
using Domain.Core.Sells.Service;
using HotChocolate.Subscriptions;

namespace API.Gate.GraphQl.Mutations
{
    [ExtendObjectType("Mutations")]
    public class ServiceMutations
    {
        private readonly Context context;
        private readonly Repository<Service> repository;

        public ServiceMutations([Service] Context context)
        {
            this.context = context;
            this.repository = new Repository<Service>(context);
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Service> CreateService(Service service, 
                                                [Service] ITopicEventSender sender)
        {
            await this.repository.CreateAsync(service);
            await sender.SendAsync(nameof(ServiceSubscription.OnServiceCreated), service);
            return service;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Service> UpdateService(Service service,
                                                [Service] ITopicEventSender sender)
        {
            try
            {
                await this.repository.UpdateAsync(service);
                await sender.SendAsync(nameof(ServiceSubscription.OnServiceChanged), service);
                return service;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Service with id == {service.Id} not found", service.Id);
            }
            catch
            {
                throw;
            }
        }


        [UseFiltering]
        public async Task<Service> RemoveService(Service service,
                                                [Service] ITopicEventSender sender)
        {
            try
            {
                await this.repository.DeleteAsync(service.Id);
                await sender.SendAsync(nameof(ServiceSubscription.OnServiceRemoved), service);
                return service;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Service with id == {service.Id} not found", service.Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
