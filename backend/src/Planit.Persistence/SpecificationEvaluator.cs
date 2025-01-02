using Microsoft.EntityFrameworkCore;
using Planit.Domain.Abstractions.Specifications;

namespace Planit.Persistence;

public static class SpecificationEvaluator
{
    public static IQueryable<T> ApplySpecification<T>(IQueryable<T> inputQuery, ISpecification<T> specification)
        where T : class
    {
        var query = inputQuery;

        // Set no tracking if read only is set
        if (specification.IsReadOnly)
        {
            query = query.AsNoTracking();
        }

        // modify the IQueryable using the specification's criteria expression
        if (specification.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }

        // Apply all expression-based includes
        query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

        // Apply all string-based includes
        query = specification.IncludesString.Aggregate(query, (current, include) => current.Include(include));

        // Apply ordering if expressions are set
        if (specification.OrderBy.Any())
        {
            // Order by for first expression
            var (firstExp, firstAsc) = specification.OrderBy.First();
            var orderQuery = firstAsc ? query.OrderBy(firstExp) : query.OrderByDescending(firstExp);

            // Apply order by for remaining expressions
            orderQuery = specification.OrderBy.Skip(1).Aggregate(orderQuery, (current, orderBy) => 
            {
                var (exp, asc) = orderBy;
                return asc ? current.ThenBy(exp) : current.ThenByDescending(exp);
            });

            // Apply the ordering to the query
            query = orderQuery;
        }

        // Apply paging if enabled
        if (specification.Skip.HasValue)
        {
            query = query.Skip(specification.Skip.Value);
        }
        
        if (specification.Take.HasValue)
        {
           query = query.Take(specification.Take.Value);
        }

        return query;
    }
}
