using MediatR;
using Microsoft.Extensions.Logging;
using Planit.Domain.Constants;
using Planit.Domain.Models;

namespace Planit.Application.Behaviors;

public class ExceptionsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly ILogger<ExceptionsBehavior<TRequest, TResponse>> logger;

    public ExceptionsBehavior(ILogger<ExceptionsBehavior<TRequest, TResponse>> logger)
    {
        this.logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while handling {request} request", typeof(TRequest).FullName);
            return CreateResult();
        }
    }

    private static TResponse CreateResult()
    {
        if (typeof(TResponse) == typeof(Result))
        {
            return (Result.Fail(Errors.Generic) as TResponse)!;
        }

        object result = typeof(Result<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResponse).GenericTypeArguments[0])
            .GetMethod(nameof(Result.Fail))!
            .Invoke(null, new object?[] { Errors.Generic })!;

        return (TResponse)result;
    }
}
