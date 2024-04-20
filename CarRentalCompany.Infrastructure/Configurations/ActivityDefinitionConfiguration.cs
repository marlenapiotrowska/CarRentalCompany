using CarRentalCompany.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalCompany.Infrastructure.Configurations
{
    public class ActivityDefinitionConfiguration : IEntityTypeConfiguration<ActivityDefinition>
    {
        public void Configure(EntityTypeBuilder<ActivityDefinition> builder)
        {
            builder
                .Property(c => c.Name)
                .IsRequired();

            builder
                .HasMany(d => d.Activities)
                .WithOne(a => a.ActivityDefinition);
        }
    }
}
