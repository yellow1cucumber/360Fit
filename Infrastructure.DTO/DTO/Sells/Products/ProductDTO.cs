using Domain.Core.Sells;

namespace Domain.Core.Sells.Products
{
    public class ProductDTO : SalableObjectDTO
    {
        public string BarCode { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
