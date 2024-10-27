using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planit.Domain.Entities;

namespace Planit.Persistence.Configurations;

public class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.HasKey(s => s.Key);
        builder.Property(s => s.Value).IsRequired();
    }
}