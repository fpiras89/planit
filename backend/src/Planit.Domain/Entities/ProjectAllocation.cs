namespace Planit.Domain.Entities;

public class ProjectAllocation
{
    public Guid Id { get; set; }
    public Guid ProjectDemandId { get; set; }
    public Guid ResourceId { get; set; }
    public double Seniority { get; set; }

    public virtual ProjectDemand ProjectDemand { get; set; }
    public virtual Resource Resource { get; set; }
}
