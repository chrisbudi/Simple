using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.HargaRekanan.GetHargaRekanan;

public sealed record GetHargaRekananQuery(
    Ulid Id
) : IQuery<GetHargaRekananResponse>;