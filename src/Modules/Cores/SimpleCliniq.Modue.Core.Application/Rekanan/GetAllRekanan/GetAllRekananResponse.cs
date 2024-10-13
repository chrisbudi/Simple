using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Rekanan.GetRekanan;

public sealed record GetAllRekananResponse(GetAllResult<MRekanan> Data);
