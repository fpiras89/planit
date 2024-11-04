using MediatR;
using Planit.Domain.Models;

namespace Planit.Application.Abstractions.Cqrs;

/// <summary>
/// Interface for a command.
/// </summary>
/// <typeparam name="TResponse">Reponse type.</typeparam>
public interface ICommand<TResponse> : IRequest<Result<TResponse>>;
