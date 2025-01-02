using Planit.Application.Abstractions.Cqrs;
using Planit.Application.Dtos;
using Planit.Application.Interfaces;
using Planit.Domain.Constants;
using Planit.Domain.Models;
using Planit.Domain.Specifications;

namespace Planit.Application.Features.Resource.Queries;

public class GetResource
{
    public record Query(Guid Id) : IQuery<ResourceDto>;

    internal class Handler : IQueryHandler<Query, ResourceDto>
    {
        private readonly IDbContext dbContext;

        public Handler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result<ResourceDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.GetFirstBySpecificationAsync(
                new GetResourceByIdSpecification(request.Id));

            if (entity == null)
                return Errors.NotFound;

            return entity.ToDto();
        }
    }
}
