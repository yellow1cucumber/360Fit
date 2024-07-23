using Domain.Core.Sells.Products;

namespace API.Gate.GraphQl.Subscriptions
{
    [ExtendObjectType("Subscription")]
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
