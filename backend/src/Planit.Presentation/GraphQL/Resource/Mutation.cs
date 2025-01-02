using GraphQL;
using Planit.Application.Abstractions.Cqrs;
using Planit.Application.Dtos;
using Planit.Application.Features.Resource.Commands;

namespace Planit.Presentation.GraphQL;
public partial class Mutation
{
    [Scoped]
    public static async Task<ResourceDto> AddResource(
        [FromServices] IRequestDispatcher requestDispatcher,
        ResourceInputDto resource)
    {
        var result = await requestDispatcher.DispatchAsync(new AddResource.Command(resource));
        return result.Value;
    }
}
