using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Morfologi.UpdateMorfologi;

public sealed record UpdateMorfologiCommand(MMorfologi Data) : ICommand<UpdateMorfologiResponse>;