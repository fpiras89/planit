using Planit.Domain.Entities;

namespace Planit.Application.Dtos;

public record ProjectDemandDto(
        Guid Id,
        Guid ProjectId,
        Guid SkillId,
        int MinLevel,
        DateOnly StartDate,
        DateOnly EndDate,
        double Effort,
        string Name,
        string? Description = default
    );

public static class ProjectDemandDtoExtensions
{
    public static ProjectDemandDto ToDto(this ProjectDemandEntity entity)
    {
        return new ProjectDemandDto(
            entity.Id,
            entity.ProjectId,
            entity.SkillId,
            entity.MinLevel,
            entity.StartDate,
            entity.EndDate,
            entity.Effort,
            entity.Name,
            entity.Description
        );
    }
}
