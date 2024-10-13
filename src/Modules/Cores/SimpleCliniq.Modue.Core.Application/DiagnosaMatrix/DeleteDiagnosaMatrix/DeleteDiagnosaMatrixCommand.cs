using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.DiagnosaMatrix.DeleteDiagnosaMatrix;

public sealed record DeleteDiagnosaMatrixCommand(int Id) : ICommand<DeleteDiagnosaMatrixResponse>;