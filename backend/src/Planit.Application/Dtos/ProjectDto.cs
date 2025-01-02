using Planit.Domain.Entities;

namespace Planit.Application.Dtos;
public record ProjectDto(
    Guid Id,
    string Name,
    DateTime? CreatedDate = default,
    DateTime? UpdatedDate = default,
    List<ProjectDemandDto>? ProjectDemands = default);

public static class ProjectDtoExtensions
{
    public static ProjectDto ToDto(this ProjectEntity entity)
    {
        return new ProjectDto(
            entity.Id,
            entity.Name,
            entity.CreatedDate,
            entity.UpdatedDate,
            entity.ProjectDemands?.Select(e => e.ToDto()).ToList());
    }
}