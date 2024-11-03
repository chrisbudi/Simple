using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Diagnosa.UpdateDiagnosa;

public sealed record UpdateDiagnosaCommand(MDiagnosa Data) : ICommand<UpdateDiagnosaResponse>;