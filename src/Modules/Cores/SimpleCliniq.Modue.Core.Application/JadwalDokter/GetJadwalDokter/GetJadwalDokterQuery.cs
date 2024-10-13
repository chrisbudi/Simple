using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.JadwalDokter.GetJadwalDokter;

public sealed record GetJadwalDokterQuery(
    int Id
) : IQuery<GetJadwalDokterResponse>;