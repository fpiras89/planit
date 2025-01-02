using Planit.Domain.Models;

namespace Planit.Application.Abstractions.Cqrs;

public interface IRequestDispatcher
{
    Task<Result> DispatchAsync(ICommand command, CancellationToken cancellationToken = default);

    Task<Result<TResponse>> DispatchAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);

    Task<Result<TResponse>> DispatchAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
}
