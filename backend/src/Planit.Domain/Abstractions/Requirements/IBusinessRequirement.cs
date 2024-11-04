namespace Planit.Domain.Abstractions.Requirements;
public interface IBusinessRequirement<T> where T : class
{
    bool IsSatisfiedBy(T entity);
    IBusinessRequirement<T> And(IBusinessRequirement<T> other);
    IBusinessRequirement<T> Or(IBusinessRequirement<T> other);
}
