using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Rekanan.GetRekanan;

public sealed record GetAllRekananQuery(
    int Page,
    int Size,
    string Search = "",
    string Order = "",
    bool OrderAsc = true
) : IQuery<GetAllRekananResponse>;