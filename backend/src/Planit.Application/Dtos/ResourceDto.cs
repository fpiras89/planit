using Planit.Domain.Entities;

namespace Planit.Application.Dtos;

public record ResourceDto(Guid Id, string Name, List<ResourceSkillDto>? Skills = null);

public static class ResourceDtoExtensions
{
    public static ResourceDto ToDto(this ResourceEntity entity)
    {
        return new ResourceDto(
            entity.Id,
            entity.Name,
            entity.ResourceSkills?.Select(e => e.ToDto()).ToList()
        );
    }
}
