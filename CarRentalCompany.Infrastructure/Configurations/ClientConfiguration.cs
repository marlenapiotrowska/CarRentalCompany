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
                .Property(c => c.Name)
                .IsRequired();

            builder
                .HasMany(c => c.ReceiptForms)
                .WithOne(f => f.Client);
        }
    }
}
