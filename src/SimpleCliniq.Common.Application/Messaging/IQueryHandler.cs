using MediatR;
using Simple.Common.Application.Messaging;
using Simple.Common.Domain;

namespace Simple.Common.Application.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
