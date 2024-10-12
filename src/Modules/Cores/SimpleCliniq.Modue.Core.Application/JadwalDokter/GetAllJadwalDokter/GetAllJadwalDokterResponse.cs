using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.JadwalDokter.GetJadwalDokter;

public sealed record GetAllJadwalDokterResponse(GetAllResult<MJadwalDokter> Data);
