using System.Linq.Expressions;

namespace Planit.Application.Interfaces;
public interface IDbContext
{
    IQueryable<T> Query<T>() where T : class;
    
    // CRUD operations
    T AddOne<T>(T entity) where T : class;
    void AddRange<T>(params T[] entities) where T : class;
    T UpdateOne<T>(T entity) where T : class;
    void UpdateRange<T>(params T[] entities) where T : class;
    T RemoveOne<T>(T entity) where T : class;
    void RemoveRange<T>(params T[] entities) where T : class;
    Task<T?> FirstAsync<T>(Expression<Func<T, bool>>? predicate = null) where T : class;
    Task<List<T>> AllAsync<T>(Expression<Func<T, bool>>? predicate = null) where T : class;
}
