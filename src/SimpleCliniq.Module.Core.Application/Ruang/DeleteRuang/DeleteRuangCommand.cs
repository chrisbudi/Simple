using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Ruang.DeleteRuang;

public sealed record DeleteRuangCommand(int Id) : ICommand<DeleteRuangResponse>;