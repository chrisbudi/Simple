using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Morfologi.DeleteMorfologi;

public sealed record DeleteMorfologiCommand(int Id) : ICommand<DeleteMorfologiResponse>;