using API.Gate.GraphQl.Exceptions;
using AutoMapper;
using DAL;
using Domain.Core.Sells.Service;
using HotChocolate.Subscriptions;
using Infrastructure.DTO.Sells.Service;
using Infrastructure.GraphQL.Subscriptions;

namespace Infrastructure.GraphQL.Mutations
{
    [ExtendObjectType("Mutations")]
    public class ServiceMutations
    {
        private readonly Context context;
        private readonly Repository<Service> repository;
        private readonly IMapper mapper;

        public ServiceMutations([Service] Context context, IMapper mapper)
        {
            this.context = context;
            repository = new Repository<Service>(context);
            this.mapper = mapper;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Service> CreateService(ServiceDTO payload,
                                                [Service] ITopicEventSender sender)
        {
            var service = mapper.Map<Service>(payload);
            await repository.CreateAsync(service);
            await sender.SendAsync(nameof(ServiceSubscription.OnServiceCreated), service);
            return service;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Service> UpdateService(ServiceDTO payload,
                                                [Service] ITopicEventSender sender)
        {
            var service = mapper.Map<Service>(payload);
            try
            {
                await repository.UpdateAsync(service);
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
                                                [Service] ITopicEventSender sender)
        {
            var service = mapper.Map<Service>(payload);
            try
            {
                await repository.DeleteAsync(service.Id);
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
