using MediatR;
using SimpleCliniq.Common.Domain;

namespace SimpleCliniq.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
