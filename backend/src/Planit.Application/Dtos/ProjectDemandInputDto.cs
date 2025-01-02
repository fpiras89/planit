using Planit.Domain.Entities;

namespace Planit.Application.Dtos;

public record ProjectDemandInputDto(
    Guid? Id,
    Guid ProjectId,
    Guid SkillId,
    int MinLevel,
    DateOnly StartDate,
    DateOnly EndDate,
    double Effort,
    string Name,
    string? Description = default);

public static class ProjectDemandInputDtoExtensions
{
    public static ProjectDemandEntity ToEntity(this ProjectDemandInputDto dto)
    {
        return new ProjectDemandEntity
        {
            Id = dto.Id ?? Guid.NewGuid(),
            ProjectId = dto.ProjectId,
            SkillId = dto.SkillId,
            MinLevel = dto.MinLevel,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Effort = dto.Effort,
            Name = dto.Name,
            Description = dto.Description
        };
    }
}