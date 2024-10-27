using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planit.Domain.Entities;

namespace Planit.Persistence.Configurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);

        // Foreign key relationship with Category
        builder.HasOne(s => s.Category)
               .WithMany(c => c.Skills)
               .HasForeignKey(s => s.CategoryId);
    }
}