using Planit.Application.Abstractions.Cqrs;
using Planit.Application.Dtos;
using Planit.Application.Interfaces;
using Planit.Domain.Constants;
using Planit.Domain.Models;
using Planit.Domain.Specifications;

namespace Planit.Application.Features.Project.Queries;
public static class GetProject
{
    public record Query(Guid ProjectId) : IQuery<ProjectDto>;

    internal class Handler : IQueryHandler<Query, ProjectDto>
    {
        private readonly IDbContext dbContext;

        public Handler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result<ProjectDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.GetFirstBySpecificationAsync(new GetProjectByIdSpecification(request.ProjectId));
           
            if (entity == null)
                return Errors.NotFound;
            
            return new ProjectDto(entity.Id, entity.Name);   
        }
    }
}
