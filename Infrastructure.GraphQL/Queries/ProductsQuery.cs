using DAL;
using Domain.Core.Sells.Products;

namespace Infrastructure.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class ProductsQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Product> ReadProducts(Context context)
            => context.Products.AsQueryable();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<StoragedProduct> ReadStoragedProducts(Context context)
            => context.StoragedProducts.AsQueryable();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<CashRegister> ReadCashRegisters(Context context)
            => context.CashRegisters.AsQueryable();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Storage> ReadStorages(Context context)
            => context.Storages.AsQueryable();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Nomenclature> ReadNomenclatures(Context context)
            => context.Nomenclatures.AsQueryable();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Supplier> ReadSuppliers(Context context)
            => context.Suppliers.AsQueryable();

    }
}
