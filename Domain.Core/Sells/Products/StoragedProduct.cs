using SlnAssembly.Attributes;

namespace Domain.Core.Sells.Products
{
    [DALRepository]
    public class StoragedProduct : Model
    {
        public Product Product { get; set; }
        public double Quantity { get; set; }
    }
}
