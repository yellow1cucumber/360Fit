using DAL;
using Domain.Core.Sells.Products;
using HotChocolate.Subscriptions;
using AutoMapper;

using Infrastructure.DTO.Sells.Products;

using Infrastructure.GraphQL.Subscriptions;
using Infrastructure.GraphQL.Exceptions;
using Infrastructure.GraphQL.Attributes;

namespace Infrastructure.GraphQL.Mutations
{
    [GQLMutation]
    [ExtendObjectType("Mutations")]
    public class ProductsMutations
    {
        private readonly Context context;
        private readonly Repository<Product> repository;

        private readonly IMapper mapper;

        public ProductsMutations([Service] Context context, IMapper mapper)
        {
            this.context = context;
            repository = new Repository<Product>(context);
            this.mapper = mapper;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Product> CreateProduct(ProductDTO payload, [Service] ITopicEventSender sender)
        {
            var product = mapper.Map<Product>(payload);
            await repository.CreateAsync(product);
            await sender.SendAsync(nameof(ProductsSubscription.OnProductCreated), product);
            return product;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Product> UpdateProduct(ProductDTO payload, [Service] ITopicEventSender sender)
        {
            var product = mapper.Map<Product>(payload);
            try
            {
                await repository.UpdateAsync(product);
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
        public async Task<Product> RemoveProduct(ProductDTO payload, [Service] ITopicEventSender sender)
        {
            var product = mapper.Map<Product>(payload);
            try
            {
                await repository.DeleteAsync(product.Id);
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
