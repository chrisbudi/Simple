using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Morfologi.GetMorfologi;

public sealed record GetAllMorfologiResponse(GetAllResult<MMorfologi> Data);
