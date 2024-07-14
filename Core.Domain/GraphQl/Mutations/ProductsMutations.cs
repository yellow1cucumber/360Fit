using DAL;
using Domain.Core.Sells.Products;

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
        public async Task<Product> CreateOrUpdateProduct([Service] Context context, Product product)
        {
            if (context.Products.Any(x => x.Id == product.Id))
            {
                context.Products.Update(product);
                await context.SaveChangesAsync();
                return product;
            }
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product;
        }

        [UseFiltering]
        public async Task<Product> RemoveProduct([Service] Context context, Product product)
        {
            if (context.Products.Contains(product))
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return product;
            }
            return product;
        }
    }
}
