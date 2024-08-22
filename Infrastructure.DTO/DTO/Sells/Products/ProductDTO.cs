namespace Infrastructure.DTO.Sells.Products
{
    public class ProductDTO : SalableObjectDTO
    {
        public string BarCode { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
