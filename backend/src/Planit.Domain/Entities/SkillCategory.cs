namespace Planit.Domain.Entities;

public class SkillCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<SkillEntity> Skills { get; set; }
}