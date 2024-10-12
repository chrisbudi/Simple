using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.SMF.GetSmf;

public sealed record GetAllSmfResponse(GetAllResult<MSmf> Data);
