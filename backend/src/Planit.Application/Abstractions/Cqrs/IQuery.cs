using MediatR;
using Planit.Domain.Models;

namespace Planit.Application.Abstractions.Cqrs;

/// <summary>
/// Interface for a query.
/// </summary>
/// <typeparam name="TResponse">Response type.</typeparam>
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
