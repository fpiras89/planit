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
    /// The list of expression-based includes.
    /// </summary>
    List<Expression<Func<T, object>>> Includes { get; }

    /// <summary>
    /// The list of string-based includes.
    /// </summary>
    List<string> IncludesString { get; }

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
    List<(Expression<Func<T, object>>, bool)> OrderBy { get; }

    bool IsReadOnly { get; }
}
