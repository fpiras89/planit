using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planit.Domain.Entities;

namespace Planit.Persistence.Configurations;

public class SettingConfiguration : IEntityTypeConfiguration<SettingEntity>
{
    public void Configure(EntityTypeBuilder<SettingEntity> builder)
    {
        builder.HasKey(s => s.Key);
        builder.Property(s => s.Value).IsRequired();
    }
}