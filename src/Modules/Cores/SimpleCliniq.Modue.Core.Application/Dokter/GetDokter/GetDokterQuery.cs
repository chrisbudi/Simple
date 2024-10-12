using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Dokter.GetDokter;

public sealed record GetDokterQuery(
    int Id
) : IQuery<GetDokterResponse>;