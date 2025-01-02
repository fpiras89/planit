namespace Planit.Domain.Entities;

public class ResourceEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<ResourceCapacityEntity> Capacities { get; set; }
    public virtual ICollection<ProjectAllocationEntity> ProjectAllocations { get; set; }
    public virtual ICollection<ResourceSkillEntity> ResourceSkills { get; set; }
}