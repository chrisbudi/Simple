using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.DTD.UpdateDtd;

public sealed record UpdateDtdCommand(MDtd Data) : ICommand<UpdateDtdResponse>;