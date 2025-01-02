using Planit.Domain.Entities;

namespace Planit.Application.Dtos;

public record ResourceSkillDto(
    Guid Id,
    Guid ResourceId,
    Guid SkillId,
    string SkillName,
    int Level,
    Guid? SkillCategoryId,
    string? SkillCategoryName);


public static class ResourceSkillDtoExtensions
{
    public static ResourceSkillDto ToDto(this ResourceSkillEntity entity)
    {
        return new ResourceSkillDto(
            entity.Id,
            entity.ResourceId,
            entity.SkillId,
            entity.Skill.Name,
            entity.Level,
            entity.Skill.CategoryId,
            entity.Skill.Category?.Name
        );
    }
}
