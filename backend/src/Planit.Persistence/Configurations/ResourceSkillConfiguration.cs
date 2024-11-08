using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planit.Domain.Entities;

namespace Planit.Persistence.Configurations;

public class ResourceSkillConfiguration : IEntityTypeConfiguration<ResourceSkillEntity>
{
    public void Configure(EntityTypeBuilder<ResourceSkillEntity> builder)
    {
        builder.HasKey(rs => rs.Id);
        builder.Property(rs => rs.Seniority).IsRequired();

        // Foreign key relationships
        builder.HasOne(rs => rs.Resource)
               .WithMany(r => r.ResourceSkills)
               .HasForeignKey(rs => rs.ResourceId);

        builder.HasOne(rs => rs.Skill)
               .WithMany(s => s.ResourceSkills)
               .HasForeignKey(rs => rs.SkillId);
    }
}