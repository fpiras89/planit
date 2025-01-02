using Planit.Application.Abstractions.Cqrs;
using Planit.Application.Dtos;
using Planit.Application.Interfaces;
using Planit.Domain.Models;

namespace Planit.Application.Features.Project.Queries;

public static class AddProject
{
    public record Command(ProjectInputDto Project) : ICommand<ProjectDto>;

    internal class Handler : ICommandHandler<Command, ProjectDto>
    {
        private readonly IDbContext dbContext;

        public Handler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result<ProjectDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = request.Project.ToEntity();
            dbContext.AddOne(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
            
            return entity.ToDto();   
        }
    }
}
