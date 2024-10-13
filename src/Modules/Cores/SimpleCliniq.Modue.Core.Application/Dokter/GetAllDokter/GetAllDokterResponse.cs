using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Dokter.GetDokter;

public sealed record GetAllDokterResponse(GetAllResult<MDokter> Data);
