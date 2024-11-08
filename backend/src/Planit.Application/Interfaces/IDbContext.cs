using Planit.Domain.Abstractions.Specifications;
using System.Linq.Expressions;

namespace Planit.Application.Interfaces;
public interface IDbContext
{    
    // CRUD operations
    T AddOne<T>(T entity) where T : class;
    void AddRange<T>(params T[] entities) where T : class;
    T UpdateOne<T>(T entity) where T : class;
    void UpdateRange<T>(params T[] entities) where T : class;
    T RemoveOne<T>(T entity) where T : class;
    void RemoveRange<T>(params T[] entities) where T : class;
    Task<T?> GetFirstAsync<T>(Expression<Func<T, bool>>? predicate = null) where T : class;
    Task<List<T>> GetAllAsync<T>(Expression<Func<T, bool>>? predicate = null) where T : class;

    Task<T?> GetFirstBySpecificationAsync<T>(ISpecification<T> specification) where T : class;
    Task<List<T>> GetAllBySpecificationAsync<T>(ISpecification<T> specification) where T : class;
}
