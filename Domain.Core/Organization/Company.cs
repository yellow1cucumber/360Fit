using Domain.Core.Organization.Contact;
using Domain.Core.Sells;
using Domain.Core.Sells.Products;
using Domain.Core.Sells.Service;
using Domain.Core.Users;

using SlnAssembly.Attributes;

namespace Domain.Core.Organization
{
    [DALRepository]
    public class Company : Model
    {
        public string PublicName { get; set; }
        public string Description {  get; set; }

        public CompanyCategory Category { get; set; }

        public Requisites Requisites { get; set; }
        public Contacts Contacts { get; set; }

        public IEnumerable<User> Users { get; set; }

        public IEnumerable<CashRegister> CashRegisters { get; set; }
        public IEnumerable<Storage> Storages { get; set; }
        public IEnumerable<Nomenclature> Nomenclatures { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }

        public IEnumerable<Service> Services { get; set; }

        public IEnumerable<Payment> Payment { get; set; }


        public enum CompanyCategory
        {
            Developer = 0,
            FitnessCentre = 1,
            SportsNutritionStore = 2,
            SportsNutritionSupplier = 3
        }
    }
}
