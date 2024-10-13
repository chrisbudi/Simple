using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.SMF.DeleteSmf;

public sealed record DeleteSmfCommand(int Id) : ICommand<DeleteSmfResponse>;