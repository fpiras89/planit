using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planit.Domain.Entities;

namespace Planit.Persistence.Configurations;

public class SkillCategoryConfiguration : IEntityTypeConfiguration<SkillCategory>
{
    public void Configure(EntityTypeBuilder<SkillCategory> builder)
    {
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.Name).IsRequired().HasMaxLength(50);

        // One-to-many relationship
        builder.HasMany(sc => sc.Skills)
               .WithOne(s => s.Category)
               .HasForeignKey(s => s.CategoryId);
    }
}