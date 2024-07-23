using Domain.Core.Sells;
using Domain.Core.Sells.PaymentRules;
using Domain.Core.Sells.Products;
using Domain.Core.Sells.Service;
using Domain.Core.Users;
using Microsoft.EntityFrameworkCore;

using ServiceCategory = Domain.Core.Sells.Category;

namespace DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) 
            : base(options) {}

        #region Users
        public DbSet<User> Users { get; set; }
        #endregion

        #region Service
        public DbSet<Card> Cards { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        #endregion

        #region Sells
        public DbSet<PaymentDate> PaymentDates { get; set; }
        public DbSet<PaymentRule> PaymentRules { get; set; }
        public DbSet<Payment> Payments { get; set; }
        #endregion

        #region Products
        public DbSet<Product> Products { get; set; }
        public DbSet<StoragedProduct> StoragedProducts { get; set; }
        public DbSet<CashRegister> CashRegisters{ get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Nomenclature> Nomenclatures { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        #endregion
    }
}
