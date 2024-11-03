using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Dokter.GetDokter;

internal sealed class GetDokterQueryHandler(IDokterRepository repository)
    : IQueryHandler<GetDokterQuery, GetDokterResponse>
{
    public async Task<Result<GetDokterResponse>> Handle(GetDokterQuery request, CancellationToken cancellationToken)
    {
        MDokter response = await repository.Get(request.Id);
        return new GetDokterResponse(response);
    }
}