using CarRentalCompany.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalCompany.Infrastructure.Configurations
{
    public class ReceiptFormConfiguration : IEntityTypeConfiguration<ReceiptForm>
    {
        public void Configure(EntityTypeBuilder<ReceiptForm> builder)
        {
            builder
                .HasOne(f => f.Client)
                .WithMany(c => c.ReceiptForms)
                .HasForeignKey(f => f.ClientId);
        }
    }
}
