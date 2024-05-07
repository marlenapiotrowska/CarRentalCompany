using CarRentalCompany.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalCompany.Infrastructure.Configurations
{
    public class ActivityInstanceConfiguration : IEntityTypeConfiguration<ActivityInstance>
    {
        public void Configure(EntityTypeBuilder<ActivityInstance> builder)
        { 
            builder
                .HasOne(a => a.ReceiptForm)
                .WithMany(f => f.Activities)
                .HasForeignKey(a => a.ReceiptFormId);
        }
    }
}
