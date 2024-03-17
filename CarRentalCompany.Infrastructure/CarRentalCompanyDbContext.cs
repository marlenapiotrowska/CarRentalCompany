using CarRentalCompany.Infrastructure.Configurations;
using CarRentalCompany.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalCompany.Infrastructure
{
    public class CarRentalCompanyDbContext : DbContext
    {
        public DbSet<ReceiptForm> ReceiptForms { get; set; }
        public DbSet<Client> Clients { get; set; }

        public CarRentalCompanyDbContext(DbContextOptions<CarRentalCompanyDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptFormConfiguration());
        }
    }
}
