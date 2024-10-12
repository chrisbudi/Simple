using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Diagnosa.GetDiagnosa;

public sealed record GetAllDiagnosaResponse(GetAllResult<MDiagnosa> Data);
