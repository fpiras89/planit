using Planit.Domain.Entities;

namespace Planit.Application.Dtos;

public record ResourceSkillInputDto(Guid? Id, Guid SkillId, Guid ResourceId, int Level);

public static class ResourceSkillInputDtoExtensions
{
    public static ResourceSkillEntity ToEntity(this ResourceSkillInputDto dto)
    {
        return new ResourceSkillEntity
        {
            Id = dto.Id ?? Guid.NewGuid(),
            SkillId = dto.SkillId,
            ResourceId = dto.ResourceId,
            Level = dto.Level
        };
    }
}