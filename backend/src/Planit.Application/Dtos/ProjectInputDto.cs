using Planit.Domain.Entities;

namespace Planit.Application.Dtos;

public record ProjectInputDto(Guid? Id, string Name, List<ProjectDemandInputDto>? ProjectDemands);

public static class ProjectInputDtoExtensions
{
    public static ProjectEntity ToEntity(this ProjectInputDto dto)
    {
        return new ProjectEntity
        {
            Id = dto.Id ?? Guid.NewGuid(),
            Name = dto.Name,
            ProjectDemands = dto.ProjectDemands?
                .Select(d => d.ToEntity()).ToList() ?? Enumerable.Empty<ProjectDemandEntity>().ToList()
        };
    }
}
