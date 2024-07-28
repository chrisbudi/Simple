using MediatR;
using Simple.Common.Domain;

namespace Simple.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
