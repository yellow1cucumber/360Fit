using Infrastructure.DTO.Organization.Contact;
using Infrastructure.DTO.Sells;
using Infrastructure.DTO.Sells.Products;
using Infrastructure.DTO.Sells.Service;
using Infrastructure.DTO.Users;

namespace Infrastructure.DTO.Organization
{
    public class CompanyDTO
    {
        public string PublicName { get; set; }
        public string Description { get; set; }

        public CompanyCategory Category { get; set; }

        public RequisitesDTO Requisites { get; set; }
        public ContactsDTO Contacts { get; set; }

        public IEnumerable<UserDTO> Staff { get; set; }
        public IEnumerable<UserDTO> Clients { get; set; }

        public IEnumerable<CashRegisterDTO> CashRegisters { get; set; }
        public IEnumerable<StorageDTO> Storages { get; set; }
        public IEnumerable<NomenclatureDTO> Nomenclatures { get; set; }
        public IEnumerable<SupplierDTO> Suppliers { get; set; }

        public IEnumerable<ServiceDTO> Services { get; set; }

        public IEnumerable<PaymentDTO> Payment { get; set; }


        public enum CompanyCategory
        {
            Developer = 0,
            FitnessCentre = 1,
            SportsNutritionStore = 2,
            SportsNutritionSupplier = 3
        }
    }
}
