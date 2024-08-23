using CarRentalCompany.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalCompany.Infrastructure.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasMany(c => c.Rentals)
                .WithOne(r => r.Car);

            builder
                .HasMany(c => c.ReceiptForms)
                .WithOne(r => r.Car);
        }
    }
}
