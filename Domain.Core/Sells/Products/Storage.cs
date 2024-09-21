using Domain.Core.Organization;

using SlnAssembly.Attributes;

namespace Domain.Core.Sells.Products
{
    [DALRepository]
    public class Storage : Model
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<StoragedProduct> Products { get; set; }

        public Company Company { get; set; }
    }
}
