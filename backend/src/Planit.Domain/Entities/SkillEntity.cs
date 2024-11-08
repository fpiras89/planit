namespace Planit.Domain.Entities;
public class SkillEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }

    public virtual SkillCategory Category { get; set; }
    public virtual ICollection<ResourceSkillEntity> ResourceSkills { get; set; }
    public virtual ICollection<ProjectDemandEntity> ProjectDemands { get; set; }
}
