namespace Planit.Domain.Entities;

public class ResourceSkillEntity
{
    public Guid Id { get; set; }
    public Guid ResourceId { get; set; }
    public Guid SkillId { get; set; }
    public int Seniority { get; set; }

    public virtual ResourceEntity Resource { get; set; }
    public virtual SkillEntity Skill { get; set; }
}