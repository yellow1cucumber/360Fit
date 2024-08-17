using Domain.ClienLogging;
using Domain.Core.Organization;
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

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Staff)
                .WithMany(u => u.StaffIn)
                .UsingEntity<Dictionary<string, object>>(
                    "CompanyStaff",
                    j => j
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_CompanyStaff_User_UserId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Company>()
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_CompanyStaff_Company_CompanyId")
                        .OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<Company>()
                .HasMany(c => c.Clients)
                .WithMany(u => u.ClientIn)
                .UsingEntity<Dictionary<string, object>>(
                    "CompanyClient",
                    j => j
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_CompanyClient_User_UserId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Company>()
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_CompanyClient_Company_CompanyId")
                        .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
