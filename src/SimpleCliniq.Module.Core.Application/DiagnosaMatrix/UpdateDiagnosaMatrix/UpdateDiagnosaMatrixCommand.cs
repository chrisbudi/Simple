using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.DiagnosaMatrix.UpdateDiagnosaMatrix;

public sealed record UpdateDiagnosaMatrixCommand(MDiagnosaMatrix Data) : ICommand<UpdateDiagnosaMatrixResponse>;