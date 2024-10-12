using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Dokter.GetDokter;

public sealed record GetAllDokterQuery(
    int Page,
    int Size,
    string Search = "",
    string Order = "",
    bool OrderAsc = true
) : IQuery<GetAllDokterResponse>;