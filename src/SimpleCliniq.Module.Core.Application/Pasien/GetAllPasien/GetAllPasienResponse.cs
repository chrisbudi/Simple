using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Pasien.GetPasien;

public sealed record GetAllPasienResponse(GetAllResult<MPasien> Data);
