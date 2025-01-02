using Planit.Domain.Abstractions.Specifications;
using Planit.Domain.Entities;

namespace Planit.Domain.Specifications;
public class GetResourceByIdSpecification : BaseSpecification<ResourceEntity>
{
    public GetResourceByIdSpecification(Guid id) : base(e => e.Id == id)
    {
        AddInclude(e => e.ResourceSkills);
        AddInclude($"{nameof(ResourceEntity.ResourceSkills)}.{nameof(ResourceSkillEntity.Skill)}");
    }
}
