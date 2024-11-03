using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Diagnosa.CreateDiagnosa;

public sealed record CreateDiagnosaCommand(MDiagnosa Data) : ICommand<CreateDiagnosaResponse>;