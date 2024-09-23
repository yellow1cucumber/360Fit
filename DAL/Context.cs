using Domain.ClienLogging;
using Domain.Core.Organization;
using Domain.Core.Organization.Contact;
using Domain.Core.Sells;
using Domain.Core.Sells.PaymentRules;
using Domain.Core.Sells.Products;
using Domain.Core.Sells.Service;
using Domain.Core.Users;
using Domain.Core.Users.Roles;

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
        public DbSet<UserCredentials> UserCredentials { get; set; }
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

        #region Organization
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<BankRequisites> BankRequisites { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Requisites> Requisites { get; set; }
        #endregion

        #region ClientLogging
        public DbSet<ClientLog> ClientLogs { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Credentials)
                .WithOne()
                .HasForeignKey<UserCredentials>(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Card)
                .WithOne()
                .HasForeignKey<Card>(uc => uc.Owner)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Credentials)
                .WithOne()
                .HasForeignKey<UserCredentials>(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasOne<Company>()
                .WithMany()
                .HasForeignKey(r => r.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
