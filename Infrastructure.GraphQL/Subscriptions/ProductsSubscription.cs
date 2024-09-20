using Domain.Core.Sells.Products;

using Infrastructure.GraphQL.Attributes;

namespace Infrastructure.GraphQL.Subscriptions
{
    [GQLSubscription]
    [ExtendObjectType("Subscriptions")]
    public class ProductsSubscription
    {
        [Subscribe]
        public Product OnProductCreated([EventMessage] Product product)
            => product;

        [Subscribe]
        public Product OnProductChanged([EventMessage] Product product)
            => product;

        [Subscribe]
        public Product OnProductRemoved([EventMessage] Product product)
            => product;
    }
}
