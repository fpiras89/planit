namespace Planit.Domain.Abstractions.Rules;
public abstract class BusinessRule : IBusinessRule
{
    private IBusinessRule? _nextRule;

    public IBusinessRule SetNext(IBusinessRule nextRule)
    {
        _nextRule = nextRule;
        return nextRule;
    }

    public virtual async Task<bool> ValidateAsync()
    {
        return (await InnerValidateAsync())
            && await (_nextRule?.ValidateAsync() ?? Task.FromResult(true));
    }

    protected abstract Task<bool> InnerValidateAsync();
}
