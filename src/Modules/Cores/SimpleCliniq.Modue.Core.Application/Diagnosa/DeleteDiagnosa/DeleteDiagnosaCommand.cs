using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Diagnosa.DeleteDiagnosa;

public sealed record DeleteDiagnosaCommand(int Id) : ICommand<DeleteDiagnosaResponse>;