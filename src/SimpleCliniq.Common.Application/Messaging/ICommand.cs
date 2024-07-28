using MediatR;
using Simple.Common.Application.Messaging;
using Simple.Common.Domain;

namespace Simple.Common.Application.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;
