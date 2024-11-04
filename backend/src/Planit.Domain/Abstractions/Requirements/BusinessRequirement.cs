namespace Planit.Domain.Abstractions.Requirements;

public abstract class BusinessRequirement<T> : IBusinessRequirement<T>
    where T : class
{
    public abstract bool IsSatisfiedBy(T entity);

    public IBusinessRequirement<T> And(IBusinessRequirement<T> other)
    {
        return new AndRequirement<T>(this, other);
    }

    public IBusinessRequirement<T> Or(IBusinessRequirement<T> other)
    {
        return new OrRequirement<T>(this, other);
    }
}
