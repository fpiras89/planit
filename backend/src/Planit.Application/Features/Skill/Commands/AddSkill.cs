using FluentValidation;
using Planit.Application.Abstractions.Cqrs;
using Planit.Application.Dtos;
using Planit.Application.Interfaces;
using Planit.Domain.Models;

namespace Planit.Application.Features.Skill.Commands;
public class AddSkill
{
    public record Command(SkillInputDto Skill) : ICommand<SkillDto>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Skill.Name).NotEmpty();
            RuleFor(x => x.Skill.Name).MinimumLength(3);
        }
    }

    internal class Handler : ICommandHandler<Command, SkillDto>
    {
        private readonly IDbContext dbContext;

        public Handler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result<SkillDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = request.Skill.ToEntity();
            dbContext.AddOne(entity);
            await dbContext.SaveChangesAsync(cancellationToken);

            return entity.ToDto();
        }
    }
}
