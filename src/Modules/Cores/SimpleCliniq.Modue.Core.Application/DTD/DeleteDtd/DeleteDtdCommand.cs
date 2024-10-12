using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.DTD.DeleteDtd;

public sealed record DeleteDtdCommand(int Id) : ICommand<DeleteDtdResponse>;