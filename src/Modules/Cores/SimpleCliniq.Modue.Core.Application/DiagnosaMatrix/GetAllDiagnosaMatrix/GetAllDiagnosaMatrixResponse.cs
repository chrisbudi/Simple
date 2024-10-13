using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.DiagnosaMatrix.GetDiagnosaMatrix;

public sealed record GetAllDiagnosaMatrixResponse(GetAllResult<MDiagnosaMatrix> Data);
