using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Ruang.GetRuang;

public sealed record GetAllRuangResponse(GetAllResult<MRuang> Data);
