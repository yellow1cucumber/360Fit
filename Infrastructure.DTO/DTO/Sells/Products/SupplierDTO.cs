using Domain.Core.Organization;

namespace Domain.Core.Sells.Products
{
    public class SupplierDTO
    {
        public RequisitesDTO Requisites { get; set; }

        public NomenclatureDTO Nomenclature { get; set; }

        public CompanyDTO Company { get; set; }
    }
}
