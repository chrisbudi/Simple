using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Morfologi.CreateMorfologi;

public sealed record CreateMorfologiCommand(MMorfologi Data) : ICommand<CreateMorfologiResponse>;