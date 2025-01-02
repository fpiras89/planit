using GraphQL;
using Planit.Application.Abstractions.Cqrs;
using Planit.Application.Dtos;
using Planit.Application.Features.Skill.Commands;

namespace Planit.Presentation.GraphQL;

public partial class Mutation
{
    [Scoped]
    public static async Task<SkillDto> AddSkill(
        [FromServices] IRequestDispatcher requestDispatcher,
        SkillInputDto skill)
    {
        var command = new AddSkill.Command(skill);
        var result = await requestDispatcher.DispatchAsync(command);
        return result.GetValueOrThrow();
    }
}
