namespace Domain.Core.Products
{
    public class Storage : Model
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<StoragedProduct> Products { get; set; }
    }
}
