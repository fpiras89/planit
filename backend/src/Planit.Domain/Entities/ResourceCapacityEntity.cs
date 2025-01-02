namespace Planit.Domain.Entities;

public class ResourceCapacityEntity
{
    public Guid Id { get; set; }
    public Guid ResourceId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public double Amount { get; set; }

    public virtual ResourceEntity Resource { get; set; }
}
