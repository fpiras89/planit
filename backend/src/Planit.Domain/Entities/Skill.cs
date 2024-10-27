namespace Planit.Domain.Entities;
public class Skill
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }

    public virtual SkillCategory Category { get; set; }
    public virtual ICollection<ResourceSkill> ResourceSkills { get; set; }
    public virtual ICollection<ProjectDemand> ProjectDemands { get; set; }
}
