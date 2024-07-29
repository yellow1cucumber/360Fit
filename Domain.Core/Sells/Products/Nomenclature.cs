using Domain.Core.Organization;

namespace Domain.Core.Sells.Products
{
    public class Nomenclature : Model
    {
        public IEnumerable<Product> Products { get; set; }

        public Company Company { get; set; }
    }
}
