using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planit.Domain.Entities;

namespace Planit.Persistence.Configurations;

public class ProjectDemandConfiguration : IEntityTypeConfiguration<ProjectDemand>
{
    public void Configure(EntityTypeBuilder<ProjectDemand> builder)
    {
        builder.HasKey(pd => pd.Id);
        builder.Property(pd => pd.Seniority).IsRequired();
        builder.Property(pd => pd.Date).IsRequired();
        builder.Property(pd => pd.Effort).IsRequired();
        builder.Property(pd => pd.Description).HasMaxLength(256);

        // Foreign key relationships
        builder.HasOne(pd => pd.Project)
            .WithMany(p => p.ProjectDemands)
            .HasForeignKey(pd => pd.ProjectId);

        builder.HasOne(pd => pd.Skill)
            .WithMany(s => s.ProjectDemands)
            .HasForeignKey(pd => pd.SkillId);
    }
}