using Domain.Core.Organization;

using SlnAssembly.Attributes;

namespace Domain.Core.Sells.Products
{
    [DALRepository]
    public class Supplier : Model
    {
        public Requisites Requisites { get; set; }

        public Nomenclature Nomenclature { get; set; }

        public Company Company { get; set; }
    }
}
