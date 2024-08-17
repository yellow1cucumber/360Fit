using Domain.Core.Organization;

namespace Domain.Core.Sells.Products
{
    public class StorageDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<StoragedProductDTO> Products { get; set; }

        public CompanyDTO Company { get; set; }
    }
}
