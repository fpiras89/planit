using System.Linq.Expressions;

namespace Planit.Domain.Abstractions.Specifications;

/// <summary>
/// Represents a specification.
/// </summary>
public interface ISpecification<T> where T : class
{
    /// <summary>
    /// The criteria expression.
    /// </summary>
    Expression<Func<T, bool>> Criteria { get; }

    /// <summary>
    /// The list of include expressions.
    /// </summary>
    List<Expression<Func<T, object>>> Includes { get; }

    /// <summary>
    /// Adds an include expression.
    /// </summary>
    int? Take { get; }

    /// <summary>
    /// The number of items to skip.
    /// </summary>
    int? Skip { get; }

    /// <summary>
    /// The list of order by expressions.
    /// </summary>
    List<Expression<Func<T, object>>> OrderBy { get; }

    /// <summary>
    /// The list of order by descendent expressions.
    /// </summary>
    List<Expression<Func<T, object>>> OrderByDesc { get; }

    bool IsReadOnly { get; }
}
