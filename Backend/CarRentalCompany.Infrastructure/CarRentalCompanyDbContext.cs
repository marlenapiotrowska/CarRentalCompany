using CarRentalCompany.Infrastructure.Configurations;
using CarRentalCompany.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalCompany.Infrastructure
{
    public class CarRentalCompanyDbContext : DbContext
    {
        public CarRentalCompanyDbContext(DbContextOptions<CarRentalCompanyDbContext> options)
            : base(options)
        {
        }

        public DbSet<ReceiptForm> ReceiptForms { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<ActivityInstance> ActivitiesInstances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptFormConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityInstanceConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new RentalConfiguration());
        }
    }
}
