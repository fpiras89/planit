using Planit.Domain.Entities;

namespace Planit.Application.Dtos;

public record ResourceInputDto(Guid? Id, string Name, List<ResourceSkillInputDto>? Skills);

public static class ResourceInputDtoExtensions
{
    public static ResourceEntity ToEntity(this ResourceInputDto dto)
    {
        return new ResourceEntity
        {
            Id = dto.Id ?? Guid.NewGuid(),
            Name = dto.Name,
            ResourceSkills = dto.Skills?
                .Select(e => e.ToEntity()).ToList() ?? Enumerable.Empty<ResourceSkillEntity>().ToList()
        };
    }
}
