using GraphQL;
using Planit.Application.Abstractions.Cqrs;
using Planit.Application.Dtos;
using Planit.Application.Features.Project.Queries;

namespace Planit.Presentation.GraphQL;
public partial class Query
{
    [Scoped]
    public static async Task<ProjectDto?> Project(
        [FromServices] IRequestDispatcher requestDispatcher,
        Guid projectId)
    {
        var result = await requestDispatcher.DispatchAsync(new GetProject.Query(projectId));
        return result.Value;
    }
}
