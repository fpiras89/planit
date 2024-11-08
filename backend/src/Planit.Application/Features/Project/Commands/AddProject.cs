using Planit.Application.Abstractions.Cqrs;
using Planit.Application.Dtos;
using Planit.Application.Interfaces;
using Planit.Domain.Entities;
using Planit.Domain.Models;

namespace Planit.Application.Features.Project.Queries;
public static class AddProject
{
    public record Command(string Name) : ICommand<ProjectDto>;

    internal class Handler : ICommandHandler<Command, ProjectDto>
    {
        private readonly IDbContext dbContext;

        public Handler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result<ProjectDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = new ProjectEntity { Name = request.Name };
            dbContext.AddOne(entity);
           
            await dbContext.SaveChangesAsync(cancellationToken);
            
            return new ProjectDto(entity.Id, entity.Name);   
        }
    }
}
