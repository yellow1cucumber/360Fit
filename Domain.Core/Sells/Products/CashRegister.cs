using Domain.Core.Organization;

namespace Domain.Core.Sells.Products
{
    public class CashRegister : Model
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Company Company { get; set; }
    }
}
