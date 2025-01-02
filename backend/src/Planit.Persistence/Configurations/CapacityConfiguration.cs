using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planit.Domain.Entities;

namespace Planit.Persistence.Configurations;

public class CapacityConfiguration : IEntityTypeConfiguration<ResourceCapacityEntity>
{
    public void Configure(EntityTypeBuilder<ResourceCapacityEntity> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Amount).IsRequired();
        builder.HasIndex(c => new { c.ResourceId, c.StartDate }).IsUnique();

        // Foreign key relationship
        builder.HasOne(c => c.Resource)
            .WithMany(r => r.Capacities)
            .HasForeignKey(c => c.ResourceId);
    }
}

