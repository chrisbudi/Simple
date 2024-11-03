using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.RadiologiRekanan.GetRadiologiRekanan;

public sealed record GetRadiologiRekananQuery(int Id) : IQuery<GetRadiologiRekananResponse>;