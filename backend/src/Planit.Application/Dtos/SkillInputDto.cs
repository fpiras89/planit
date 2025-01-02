using Planit.Domain.Entities;

namespace Planit.Application.Dtos;

public record SkillInputDto(string Name, Guid? Id = default, Guid? CategoryId = default);

public static class SkillInputDtoExtensions
{
    public static SkillEntity ToEntity(this SkillInputDto dto)
    {
        return new SkillEntity
        {
            Id = dto.Id ?? Guid.NewGuid(),
            Name = dto.Name,
            CategoryId = dto.CategoryId
        };
    }
}
