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
        string name)
    {
        var result = await requestDispatcher.DispatchAsync(new AddProject.Command(name));
        return result.Value;
    }
}
