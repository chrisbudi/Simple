using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.JadwalDokter.GetJadwalDokter;

public sealed record GetAllJadwalDokterQuery(
    int Page,
    int Size,
    string Search = "",
    string Order = "",
    bool OrderAsc = true
) : IQuery<GetAllJadwalDokterResponse>;