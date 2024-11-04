namespace Planit.Domain.Abstractions.Requirements;

public class OrRequirement<T> : BusinessRequirement<T>
    where T : class
{
    private readonly IBusinessRequirement<T> _leftSpecification;
    private readonly IBusinessRequirement<T> _rightSpecification;

    public OrRequirement(IBusinessRequirement<T> leftSpecification, IBusinessRequirement<T> rightSpecification)
    {
        _leftSpecification = leftSpecification;
        _rightSpecification = rightSpecification;
    }

    public override bool IsSatisfiedBy(T entity)
    {
        return _leftSpecification.IsSatisfiedBy(entity) || _rightSpecification.IsSatisfiedBy(entity);
    }
}
