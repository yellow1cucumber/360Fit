using Domain.Core.Sells;

using SlnAssembly.Attributes;

namespace Domain.Core.Sells.Products
{
    [DALRepository]
    public class Product : SalableObject
    {
        public string BarCode { get; set; }
        public Category Category { get; set; }
    }
}
