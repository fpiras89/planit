using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planit.Domain.Models;

/// <summary>
/// Encapsulates the result of an operation.
/// </summary>
public class Result
{
    public bool Succeeded { get; }
    public bool Failed => !Succeeded;
    public Error? Error { get; }

    public Result(bool succeeded, Error? error = null)
    {
        Succeeded = succeeded;
        Error = error;
    }

    public static Result Success() => new Result(true);

    public static Result Fail(Error error) => new Result(false, error);
}

/// <summary>
/// Encapsulates the result of an operation with a value.
/// </summary>
/// <typeparam name="TValue"></typeparam>
public class Result<TValue> : Result
{
    /// <summary>
    /// The value.
    /// </summary>
    public TValue Value { get; }

    public Result(bool succeeded, TValue value, Error? error = null)
        : base(succeeded, error)
    {
        Value = value;
    }

    /// <summary>
    /// Returns a successful result with a value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static Result<TValue> Success(TValue value) => new Result<TValue>(true, value);
    
    /// <summary>
    /// Returns a failed result with an error.
    /// </summary>
    /// <param name="error">The error.</param>
    /// <returns></returns>
    public new static Result<TValue> Fail(Error error) => new Result<TValue>(false, default!, error);

    /// <summary>
    /// Implicitly converts a value to a successful result.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Result<TValue>(TValue value) => new (true, value);

    /// <summary>
    /// Implicitly converts an error to a failed result.
    /// </summary>
    /// <param name="error">The error.</param>
    public static implicit operator Result<TValue>(Error error) => new (false, default!, error);

    /// <summary>
    /// Matches the result with a success or failure function.
    /// </summary>
    /// <param name="success"></param>
    /// <param name="failure"></param>
    /// <returns></returns>
    public Result<TValue> Match(Func<TValue, Result<TValue>> success, Func<Error, Result<TValue>> failure)
    {
        if (Succeeded)
        {
            return success(Value!);
        }
        return failure(Error!);
    }
}