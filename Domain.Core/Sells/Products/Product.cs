using Domain.Core.Sells;

namespace Domain.Core.Sells.Products
{
    public class Product : SalableObject
    {
        public string BarCode { get; set; }
        public Category Category { get; set; }
    }
}
