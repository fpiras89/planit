﻿using MediatR;
using Planit.Domain.Models;

namespace Planit.Application.Abstractions.Cqrs;
public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
    where TRequest : IQuery<TResponse>;
