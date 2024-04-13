using CarRentalCompany.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalCompany.Infrastructure.Configurations
{
    public class ReceiptFormActivitiesConfiguration : IEntityTypeConfiguration<ReceiptFormActivities>
    {
        public void Configure(EntityTypeBuilder<ReceiptFormActivities> builder)
        {
            builder
                .HasOne(f => f.ReceiptForm)
                .WithMany(a => a.ReceiptFormActivities)
                .HasForeignKey(f => f.ReceiptFormId);

            builder
                .HasOne(a => a.Activity)
                .WithMany(f => f.ReceiptFormActivities)
                .HasForeignKey(a => a.ActivityId);
        }
    }
}
