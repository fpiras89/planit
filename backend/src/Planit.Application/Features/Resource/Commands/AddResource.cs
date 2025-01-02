using Planit.Application.Abstractions.Cqrs;
using Planit.Application.Dtos;
using Planit.Application.Interfaces;
using Planit.Domain.Entities;
using Planit.Domain.Models;

namespace Planit.Application.Features.Resource.Commands;

public class AddResource
{
    public record Command(ResourceInputDto Resource) : ICommand<ResourceDto>;

    internal class Handler : ICommandHandler<Command, ResourceDto>
    {
        private readonly IDbContext dbContext;

        public Handler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result<ResourceDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = request.Resource.ToEntity();

            dbContext.AddOne(entity);

            request.Resource.Skills?.ForEach(skill => entity.ResourceSkills.Add(skill.ToEntity()));

            await dbContext.SaveChangesAsync(cancellationToken);
            
            return entity.ToDto();
        }
    }
}
