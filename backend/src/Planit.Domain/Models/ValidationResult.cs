namespace Planit.Domain.Models;

public class ValidationResult : Result
{
    public IEnumerable<Error> Errors { get; }

    public ValidationResult(IEnumerable<Error> errors)
        : base(false, Constants.Errors.Validation)
    {
        Errors = errors;
    }

    public static ValidationResult WithErrors(IEnumerable<Error> errors) => new ValidationResult(errors);
}

public class ValidationResult<TValue> : Result<TValue>
{
    public IEnumerable<Error> Errors { get; }

    public ValidationResult(IEnumerable<Error> errors)
        : base(false, default!, Constants.Errors.Validation)
    {
        Errors = errors;
    }

    public static ValidationResult<TValue> WithErrors(IEnumerable<Error> errors) => new ValidationResult<TValue>(errors);
}