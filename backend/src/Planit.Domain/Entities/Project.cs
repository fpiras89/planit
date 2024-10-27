namespace Planit.Domain.Entities;

public class Project
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<ProjectDemand> ProjectDemands { get; set; }
}
