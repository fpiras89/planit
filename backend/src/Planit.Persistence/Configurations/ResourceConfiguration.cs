using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planit.Domain.Entities;

namespace Planit.Persistence.Configurations;

public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Name).IsRequired().HasMaxLength(50);

        // One-to-many relationship
        builder.HasMany(r => r.Capacities)
               .WithOne(c => c.Resource)
               .HasForeignKey(c => c.ResourceId);

        builder.HasMany(r => r.ProjectAllocations)
               .WithOne(pa => pa.Resource)
               .HasForeignKey(pa => pa.ResourceId);

        builder.HasMany(r => r.ResourceSkills)
               .WithOne(rs => rs.Resource)
               .HasForeignKey(rs => rs.ResourceId);
    }
}