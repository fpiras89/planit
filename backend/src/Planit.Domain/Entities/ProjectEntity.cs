using Planit.Domain.Abstractions.Entities;

namespace Planit.Domain.Entities;

public class ProjectEntity : IAuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<ProjectDemandEntity> ProjectDemands { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
}
