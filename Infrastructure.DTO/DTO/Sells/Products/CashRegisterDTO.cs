using Domain.Core.Organization;

namespace Domain.Core.Sells.Products
{
    public class CashRegisterDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CompanyDTO Company { get; set; }
    }
}
