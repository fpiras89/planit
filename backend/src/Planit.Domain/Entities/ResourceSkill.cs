namespace Planit.Domain.Entities;

public class ResourceSkill
{
    public Guid Id { get; set; }
    public Guid ResourceId { get; set; }
    public Guid SkillId { get; set; }
    public int Seniority { get; set; }

    public virtual Resource Resource { get; set; }
    public virtual Skill Skill { get; set; }
}