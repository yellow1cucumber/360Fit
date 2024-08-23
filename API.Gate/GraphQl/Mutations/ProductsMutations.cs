using DAL;
using Domain.Core.Sells.Products;
using API.Gate.GraphQl.Exceptions;
using HotChocolate.Subscriptions;
using API.Gate.GraphQl.Subscriptions;


namespace API.Gate.GraphQl.Mutations
{
    [ExtendObjectType("Mutations")]
    public class ProductsMutations
    {
        private readonly Context context;
        private readonly Repository<Product> repository;

        public ProductsMutations([Service] Context context)
        {
            this.context = context;
            this.repository = new Repository<Product>(context);
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Product> CreateProduct(Product product, [Service] ITopicEventSender sender)
        {
            await this.repository.CreateAsync(product);
            await sender.SendAsync(nameof(ProductsSubscription.OnProductCreated), product);
            return product;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Product> UpdateProduct(Product product, [Service] ITopicEventSender sender)
        {
            try
            {
                await this.repository.UpdateAsync(product);
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
        public async Task<Product> RemoveProduct(Product product, [Service] ITopicEventSender sender)
        {
            try
            {
                await this.repository.DeleteAsync(product.Id);
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
