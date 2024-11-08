using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planit.Domain.Entities;

namespace Planit.Persistence.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);

        // One-to-many relationship between Project and ProjectDemandEntity
        builder.HasMany(p => p.ProjectDemands)
            .WithOne(pd => pd.Project)
            .HasForeignKey(pd => pd.ProjectId);
    }
}