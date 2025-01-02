using GraphQL;
using Planit.Application.Abstractions.Cqrs;
using Planit.Application.Dtos;
using Planit.Application.Features.Project.Queries;

namespace Planit.Presentation.GraphQL;
public partial class Mutation
{
    [Scoped]
    public static async Task<ProjectDto> AddProject(
        [FromServices] IRequestDispatcher requestDispatcher,
        ProjectInputDto project)
    {
        var result = await requestDispatcher.DispatchAsync(new AddProject.Command(project));
        return result.Value;
    }

    [Scoped]
    public static async Task<ProjectDto> AddProjectDemand(
        [FromServices] IRequestDispatcher requestDispatcher,
        Guid projectId, List<ProjectDemandInputDto> projectDemands)
    {
        var result = await requestDispatcher.DispatchAsync(new AddProjectDemands.Command(projectId, projectDemands));
        return result.Value;
    }
}
