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

        public IEnumerable<User> Users { get; set; } = Enumerable.Empty<User>();

        public IEnumerable<CashRegister> CashRegisters { get; set; } = Enumerable.Empty<CashRegister>();
        public IEnumerable<Storage> Storages { get; set; } = Enumerable.Empty<Storage>();
        public IEnumerable<Nomenclature> Nomenclatures { get; set; } = Enumerable.Empty<Nomenclature>();
        public IEnumerable<Supplier> Suppliers { get; set; } = Enumerable.Empty<Supplier>();

        public IEnumerable<Service> Services { get; set; } = Enumerable.Empty<Service>();

        public IEnumerable<Payment> Payment { get; set; } = Enumerable.Empty<Payment>();


        public enum CompanyCategory
        {
            Developer = 0,
            FitnessCentre = 1,
            SportsNutritionStore = 2,
            SportsNutritionSupplier = 3
        }
    }
}
