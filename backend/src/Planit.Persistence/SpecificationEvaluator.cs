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

        // Includes all expression-based includes
        query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

        // Apply ordering if expressions are set
        if (specification.OrderBy.Any())
        {
            // Order by first expression
            var orderQuery = query.OrderBy(specification.OrderBy.First());
            // Apply order by remaining expressions
            orderQuery = specification.OrderByDesc.Skip(1).Aggregate(orderQuery, (current, orderByDesc) => current.ThenBy(orderByDesc));
            // Apply the ordering to the query
            query = orderQuery;
        } 
        else if (specification.OrderByDesc.Any())
        {
            var orderQuery = query.OrderByDescending(specification.OrderByDesc.First());
            orderQuery = specification.OrderByDesc.Skip(1).Aggregate(orderQuery, (current, orderByDesc) => current.ThenByDescending(orderByDesc));
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
