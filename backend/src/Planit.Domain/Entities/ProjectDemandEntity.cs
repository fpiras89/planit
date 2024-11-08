namespace Planit.Domain.Entities;

public class ProjectDemandEntity
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid SkillId { get; set; }
    public int Seniority { get; set; }
    public DateTime Date { get; set; }
    public double Effort { get; set; }
    public string Description { get; set; }

    public virtual ProjectEntity Project { get; set; }
    public virtual SkillEntity Skill { get; set; }
}