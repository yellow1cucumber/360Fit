using Domain.Core.Organization;

namespace Domain.Core.Sells.Products
{
    public class Supplier : Model
    {
        public Requisites Requisites { get; set; }

        public Nomenclature Nomenclature { get; set; }

        public Company Company { get; set; }
    }
}
