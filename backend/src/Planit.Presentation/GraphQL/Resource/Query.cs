using GraphQL;
using Planit.Application.Abstractions.Cqrs;
using Planit.Application.Dtos;
using Planit.Application.Features.Resource.Queries;

namespace Planit.Presentation.GraphQL;
public partial class Query
{
    [Scoped]
    public static async Task<ResourceDto?> Resource(
        [FromServices] IRequestDispatcher requestDispatcher,
        Guid resourceId)
    {
        var result = await requestDispatcher.DispatchAsync(new GetResource.Query(resourceId));
        return result.Value;
    }
}
