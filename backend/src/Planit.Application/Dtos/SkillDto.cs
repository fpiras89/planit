using Planit.Domain.Entities;

namespace Planit.Application.Dtos;

public record SkillDto(Guid Id, string Name, Guid? CategoryId, string? CategoryName);

public static class SkillDtoExtensions
{
    public static SkillDto ToDto(this SkillEntity entity)
    {
        return new SkillDto(entity.Id, entity.Name, entity.CategoryId, entity.Category?.Name);
    }
}
