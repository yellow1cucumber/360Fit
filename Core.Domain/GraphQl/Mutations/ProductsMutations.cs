using DAL;
using Domain.Core.Sells.Products;
using API.Gate.GraphQl.Exceptions;

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
        public async Task<Product> CreateProduct(Product product)
        {
            await this.repository.CreateAsync(product);
            return product;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Product> UpdateProduct(Product product)
        {
            try
            {
                await this.repository.UpdateAsync(product);
                return product;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new NotFound($"Product with id == {product.Id} not found", product.Id);
            }
            catch
            {
                throw;
            }
        }


        [UseFiltering]
        public async Task<Product> RemoveProduct(Product product)
        {
            try
            {
                await this.repository.DeleteAsync(product.Id);
                return product;
            }
            catch (IndexOutOfRangeException ex)
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
