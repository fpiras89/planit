using System.Linq.Expressions;

namespace Planit.Domain.Abstractions.Specifications;

public abstract class BaseSpecification<T> : ISpecification<T> where T : class
{
    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; private set; }

    public List<Expression<Func<T, object>>> Includes { get; private set; } = new();

    public List<Expression<Func<T, object>>> OrderBy { get; private set; } = new();

    public List<Expression<Func<T, object>>> OrderByDesc { get; private set; } = new();

    public int? Take { get; private set; }

    public int? Skip { get; private set; }

    public bool IsReadOnly { get; private set; }

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy.Add(orderByExpression);
    }

    protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDesc.Add(orderByDescExpression);
    }

    protected void ApplyPagination(int? take = null, int? skip = null)
    {
        Take = take;
        Skip = skip;
    }

    protected void SetReadOnly()
    {
        IsReadOnly = true;
    }
}