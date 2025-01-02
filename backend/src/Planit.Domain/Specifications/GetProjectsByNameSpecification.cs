using Planit.Domain.Abstractions.Specifications;
using Planit.Domain.Entities;

namespace Planit.Domain.Specifications;

public class GetProjectsByNameSpecification : BaseSpecification<ProjectEntity>
{
    public GetProjectsByNameSpecification(string name, int? take = null, int? skip = null)
        : base(e => e.Name.Contains(name))
    {
        AddOrderBy(e => e.Name);
        ApplyPagination(take, skip);
    }
}
