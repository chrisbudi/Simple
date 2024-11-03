using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.SMF.CreateSmf;

public sealed record CreateSmfCommand(MSmf Data) : ICommand<CreateSmfResponse>;