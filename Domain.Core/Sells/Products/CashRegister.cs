using Domain.Core.Organization;

using SlnAssembly.Attributes;

namespace Domain.Core.Sells.Products
{
    [DALRepository]
    public class CashRegister : Model
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Company Company { get; set; }
    }
}
