using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Tindakan.GetTindakan;

public sealed record GetAllTindakanResponse(GetAllResult<MTindakan> Data);
