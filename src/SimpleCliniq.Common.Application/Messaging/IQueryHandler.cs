using MediatR;
using SimpleCliniq.Common.Domain;

namespace SimpleCliniq.Common.Application.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
