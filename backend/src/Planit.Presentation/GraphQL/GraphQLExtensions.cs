using GraphQL;
using Planit.Domain.Constants;
using Planit.Domain.Models;

namespace Planit.Presentation.GraphQL;
public static class GraphQLExtensions
{
    public static TValue GetValueOrThrow<TValue>(this Result<TValue> result)
    {
        return result.GetResultOrThrow().Value;
    }

    public static Result<TValue> GetResultOrThrow<TValue>(this Result<TValue> result)
    {
        if (result.Failed)
        {
            if (result is ValidationResult<TValue> validationResult)
            {
                ThrowExecutionErrorFromValidationResult(validationResult);
            }
            else
            {
                ThrowExecutionErrorFromResult(result);
            }
        }
        return result;
    }

    public static Result GetResultOrThrow(this Result result)
    {
        if (result.Failed)
        {
            if (result is ValidationResult validationResult)
            {
                ThrowExecutionErrorFromValidationResult(validationResult);
            }
            else
            {
                ThrowExecutionErrorFromResult(result);
            }
        }
        return result;
    }

    private static void ThrowExecutionErrorFromResult(Result result)
    {
        var error = result.Error ?? Errors.Generic;
        throw new ExecutionError(error.Message);
    }

    private static void ThrowExecutionErrorFromValidationResult(ValidationResult validationResult)
    {
        var errorDictionary = validationResult.Errors.ToDictionary(e => e.Code, e => e.Message);
        throw new ExecutionError(validationResult.Error!.Message, errorDictionary);
    }

    private static void ThrowExecutionErrorFromValidationResult<TValue>(ValidationResult<TValue> validationResult)
    {
        var errorDictionary = validationResult.Errors.ToDictionary(e => e.Code, e => e.Message);
        throw new ExecutionError(validationResult.Error!.Message, errorDictionary);
    }
}
