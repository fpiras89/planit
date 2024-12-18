﻿namespace Planit.Domain.Entities;

public class ProjectEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<ProjectDemandEntity> ProjectDemands { get; set; }
}
