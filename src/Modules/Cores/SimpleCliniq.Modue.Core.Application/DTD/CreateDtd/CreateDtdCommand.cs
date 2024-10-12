using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.DTD.CreateDtd;

public sealed record CreateDtdCommand(MDtd Data) : ICommand<CreateDtdResponse>;