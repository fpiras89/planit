using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planit.Domain.Entities;

namespace Planit.Persistence.Configurations;

public class ProjectAllocationConfiguration : IEntityTypeConfiguration<ProjectAllocation>
{
    public void Configure(EntityTypeBuilder<ProjectAllocation> builder)
    {
        builder.HasKey(pa => pa.Id);
        builder.Property(pa => pa.Seniority).IsRequired();

        // Foreign key relationships
        builder.HasOne(pa => pa.ProjectDemand)
            .WithMany()
            .HasForeignKey(pa => pa.ProjectDemandId);

        builder.HasOne(pa => pa.Resource)
            .WithMany(r => r.ProjectAllocations)
            .HasForeignKey(pa => pa.ResourceId);
    }
}