namespace Planit.Domain.Entities;

public class ProjectAllocationEntity
{
    public Guid Id { get; set; }
    public Guid ProjectDemandId { get; set; }
    public Guid ResourceId { get; set; }
    public double Seniority { get; set; }

    public virtual ProjectDemandEntity ProjectDemand { get; set; }
    public virtual ResourceEntity Resource { get; set; }
}
