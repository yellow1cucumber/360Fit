using Domain.Core.Organization;

using SlnAssembly.Attributes;

namespace Domain.Core.Sells.Products
{
    [DALRepository]
    public class Nomenclature : Model
    {
        public IEnumerable<Product> Products { get; set; }

        public Company Company { get; set; }
    }
}
