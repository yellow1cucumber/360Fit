using Domain.Core.Organization;

namespace Domain.Core.Sells.Products
{
    public class NomenclatureDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; }

        public CompanyDTO Company { get; set; }
    }
}
