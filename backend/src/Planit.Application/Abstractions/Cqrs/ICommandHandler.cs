using MediatR;
using Planit.Domain.Models;

namespace Planit.Application.Abstractions.Cqrs;

public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
    where TRequest : ICommand<TResponse>;