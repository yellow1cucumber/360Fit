using Infrastructure.DTO.Organization;

namespace Infrastructure.DTO.Sells.Products
{
    public class NomenclatureDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; }

        public CompanyDTO Company { get; set; }
    }
}
