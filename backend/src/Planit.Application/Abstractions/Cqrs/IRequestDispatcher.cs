using MediatR;
using Planit.Domain.Models;

namespace Planit.Application.Abstractions.Cqrs;

public interface IRequestDispatcher
{
    Task<Result> DispatchAsync(ICommand command, CancellationToken cancellationToken = default);

    Task<Result<TResponse>> DispatchAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);

    Task<Result<TResponse>> DispatchAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
}

public class RequestDispatcher : IRequestDispatcher
{
    private readonly IMediator _mediator;

    public RequestDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<Result> DispatchAsync(ICommand command, CancellationToken cancellationToken = default)
    {
        return _mediator.Send(command, cancellationToken);
    }

    public Task<Result<TResponse>> DispatchAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
    {
        return _mediator.Send(command, cancellationToken);
    }

    public Task<Result<TResponse>> DispatchAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        return _mediator.Send(query, cancellationToken);
    }
}