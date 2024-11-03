using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.RadiologiHarga.GetRadiologiHarga;

public sealed record GetRadiologiHargaQuery(int Id) : IQuery<GetRadiologiHargaResponse>;