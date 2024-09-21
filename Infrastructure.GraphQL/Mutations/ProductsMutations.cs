using Domain.Core.Sells.Products;
using HotChocolate.Subscriptions;
using AutoMapper;

using Infrastructure.DTO.Sells.Products;

using Infrastructure.GraphQL.Subscriptions;
using Infrastructure.GraphQL.Exceptions;
using Infrastructure.GraphQL.Attributes;

#region TYPEDEF
using Products = DAL.Repository<Domain.Core.Sells.Products.Product>;
#endregion

namespace Infrastructure.GraphQL.Mutations
{
    [GQLMutation]
    [ExtendObjectType("Mutations")]
    public class ProductsMutations
    {
        private readonly IMapper mapper;

        public ProductsMutations(IMapper mapper)
            => this.mapper = mapper;

        [UseProjection]
        [UseFiltering]
        public async Task<Product> CreateProduct(ProductDTO payload, 
                                                [Service] ITopicEventSender sender,
                                                [Service] Products products)
        {
            var product = mapper.Map<Product>(payload);
            await products.CreateAsync(product);
            await sender.SendAsync(nameof(ProductsSubscription.OnProductCreated), product);
            return product;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Product> UpdateProduct(ProductDTO payload,
                                                [Service] ITopicEventSender sender,
                                                [Service] Products products)
        {
            var product = mapper.Map<Product>(payload);
            try
            {
                await products.UpdateAsync(product);
                await sender.SendAsync(nameof(ProductsSubscription.OnProductChanged), product);
                return product;
            }
            catch (IndexOutOfRangeException)
            {
                throw new NotFound($"Product with id == {product.Id} not found", product.Id);
            }
            catch
            {
                throw;
            }
        }


        [UseFiltering]
        public async Task<Product> RemoveProduct(ProductDTO payload,
                                                [Service] ITopicEventSender sender,
                                                [Service] Products products)
        {
            var product = mapper.Map<Product>(payload);
            try
            {
                await products.DeleteAsync(product.Id);
                await sender.SendAsync(nameof(ProductsSubscription.OnProductRemoved), product);
                return product;
            }
            catch (IndexOutOfRangeException)
            {
                throw new NotFound($"Product with id == {product.Id} not found", product.Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
