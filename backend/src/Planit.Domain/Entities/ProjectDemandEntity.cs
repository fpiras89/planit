namespace Planit.Domain.Entities;

public class ProjectDemandEntity
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid SkillId { get; set; }
    public int MinLevel { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public double Effort { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public virtual ProjectEntity Project { get; set; }
    public virtual SkillEntity Skill { get; set; }
}