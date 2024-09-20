using Domain.Core.Sells.Service;

using Infrastructure.GraphQL.Attributes;

namespace Infrastructure.GraphQL.Subscriptions
{
    [GQLSubscription]
    [ExtendObjectType("Subscriptions")]
    public class ServiceSubscription
    {
        [Subscribe]
        public Service OnServiceCreated([EventMessage] Service service)
            => service;

        [Subscribe]
        public Service OnServiceChanged([EventMessage] Service service)
            => service;

        [Subscribe]
        public Service OnServiceRemoved([EventMessage] Service service)
            => service;
    }
}
