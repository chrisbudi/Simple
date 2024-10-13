using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.SMF.UpdateSmf;

public sealed record UpdateSmfCommand(MSmf Data) : ICommand<UpdateSmfResponse>;