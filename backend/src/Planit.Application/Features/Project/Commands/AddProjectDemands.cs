using FluentValidation;
using Planit.Application.Abstractions.Cqrs;
using Planit.Application.Dtos;
using Planit.Application.Interfaces;
using Planit.Domain.Constants;
using Planit.Domain.Models;
using Planit.Domain.Specifications;

namespace Planit.Application.Features.Project.Queries;
public static class AddProjectDemands
{
    public record Command(Guid ProjectId, List<ProjectDemandInputDto> ProjectDemands) : ICommand<ProjectDto>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.ProjectId).NotEmpty();
            
            RuleFor(x => x.ProjectDemands).NotEmpty();
            
            RuleForEach(x => x.ProjectDemands)
                .Must((command, projectDemand) => projectDemand.ProjectId == command.ProjectId)
                .WithMessage("The projectId of all project demand items must be equal to the projectId of the command.");
            
            RuleForEach(x => x.ProjectDemands)
                .Must((command, projectDemand) => projectDemand.StartDate <= projectDemand.EndDate)
                .WithMessage("The start date of all project demand items must be lower or equal the end date.");

        }
    }

    internal class Handler : ICommandHandler<Command, ProjectDto>
    {
        private readonly IDbContext dbContext;

        public Handler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result<ProjectDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var projectEntity = await dbContext.GetFirstBySpecificationAsync(
                new GetProjectByIdSpecification(request.ProjectId));
            
            if (projectEntity == null)
            {
                return Errors.NotFound;
            }

            request.ProjectDemands.ForEach(projectDemand => projectEntity.ProjectDemands.Add(projectDemand.ToEntity()));  
            
            await dbContext.SaveChangesAsync(cancellationToken);
            
            return projectEntity.ToDto();   
        }
    }
}
