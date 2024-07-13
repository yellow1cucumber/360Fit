using Domain.Core.Organization;

namespace Domain.Core.Products
{
    public class Supplier : Model
    {
        public Requisites Requisites { get; set; }

        public Nomenclature Nomenclature { get; set; }
    }
}
