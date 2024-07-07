using CarRentalCompany.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalCompany.Infrastructure.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .HasMany(c => c.ReceiptForms)
                .WithOne(f => f.Client);

            builder
                .HasMany(c => c.Rentals)
                .WithOne(r => r.Client);
        }
    }
}
