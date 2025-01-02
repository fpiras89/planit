using Planit.Domain.Abstractions.Specifications;
using Planit.Domain.Entities;

namespace Planit.Domain.Specifications;

public class GetProjectByIdSpecification : BaseSpecification<ProjectEntity>
{
    public GetProjectByIdSpecification(Guid Id, bool includeDemands = true) : base(e => e.Id == Id)
    {
        if (includeDemands)
        {
            AddInclude(e => e.ProjectDemands);
        }
    }
}