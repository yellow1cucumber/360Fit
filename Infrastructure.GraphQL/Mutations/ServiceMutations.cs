using AutoMapper;
using Domain.Core.Sells.Service;
using HotChocolate.Subscriptions;
using Infrastructure.DTO.Sells.Service;

using Infrastructure.GraphQL.Subscriptions;
using Infrastructure.GraphQL.Exceptions;
using Infrastructure.GraphQL.Attributes;

#region TYPEDEF
using Services = DAL.Repository<Domain.Core.Sells.Service.Service>;
#endregion

namespace Infrastructure.GraphQL.Mutations
{
    [GQLMutation]
    [ExtendObjectType("Mutations")]
    public class ServiceMutations
    {
        private readonly IMapper mapper;

        public ServiceMutations(IMapper mapper)
            => this.mapper = mapper;

        [UseProjection]
        [UseFiltering]
        public async Task<Service> CreateService(ServiceDTO payload,
                                                [Service] ITopicEventSender sender,
                                                [Service] Services services)
        {
            var service = mapper.Map<Service>(payload);
            await services.CreateAsync(service);
            await sender.SendAsync(nameof(ServiceSubscription.OnServiceCreated), service);
            return service;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Service> UpdateService(ServiceDTO payload,
                                                [Service] ITopicEventSender sender,
                                                [Service] Services services)
        {
            var service = mapper.Map<Service>(payload);
            try
            {
                await services.UpdateAsync(service);
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
        public async Task<Service> RemoveService(ServiceDTO payload,
                                                [Service] ITopicEventSender sender,
                                                [Service] Services services)
        {
            var service = mapper.Map<Service>(payload);
            try
            {
                await services.DeleteAsync(service.Id);
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
