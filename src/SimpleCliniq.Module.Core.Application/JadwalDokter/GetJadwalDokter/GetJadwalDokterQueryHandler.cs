using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.JadwalDokter.GetJadwalDokter;

internal sealed class GetJadwalDokterQueryHandler(IJadwalDokterRepository repository)
    : IQueryHandler<GetJadwalDokterQuery, GetJadwalDokterResponse>
{
    public async Task<Result<GetJadwalDokterResponse>> Handle(GetJadwalDokterQuery request, CancellationToken cancellationToken)
    {
        MJadwalDokter response = await repository.Get(request.Id);
        return new GetJadwalDokterResponse(response);
    }
}