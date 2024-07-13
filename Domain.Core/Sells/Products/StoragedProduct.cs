namespace Domain.Core.Sells.Products
{
    public class StoragedProduct : Model
    {
        public Product Product { get; set; }
        public double Quantity { get; set; }
    }
}
