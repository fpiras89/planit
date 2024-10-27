namespace Planit.Domain.Entities;

public class Resource
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Capacity> Capacities { get; set; }
    public virtual ICollection<ProjectAllocation> ProjectAllocations { get; set; }
    public virtual ICollection<ResourceSkill> ResourceSkills { get; set; }
}