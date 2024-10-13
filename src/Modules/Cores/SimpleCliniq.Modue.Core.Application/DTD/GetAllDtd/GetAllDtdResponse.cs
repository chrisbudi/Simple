using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.DTD.GetDtd;

public sealed record GetAllDtdResponse(GetAllResult<MDtd> Data);
