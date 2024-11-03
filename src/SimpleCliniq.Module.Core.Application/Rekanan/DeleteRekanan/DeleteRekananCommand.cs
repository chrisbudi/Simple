using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Rekanan.DeleteRekanan;

public sealed record DeleteRekananCommand(int Id) : ICommand<DeleteRekananResponse>;