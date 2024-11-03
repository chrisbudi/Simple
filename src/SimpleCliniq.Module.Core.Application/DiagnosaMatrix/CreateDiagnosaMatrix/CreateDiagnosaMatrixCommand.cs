using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.DiagnosaMatrix.CreateDiagnosaMatrix;

public sealed record CreateDiagnosaMatrixCommand(MDiagnosaMatrix Data) : ICommand<CreateDiagnosaMatrixResponse>;