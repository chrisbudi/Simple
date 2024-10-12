using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.JadwalDokter.GetJadwalDokter;

internal sealed class GetAllJadwalDokterQueryHandler(IJadwalDokterRepository repository)
    : IQueryHandler<GetAllJadwalDokterQuery, GetAllJadwalDokterResponse>
{
    public async Task<Result<GetAllJadwalDokterResponse>> Handle(GetAllJadwalDokterQuery request, CancellationToken cancellationToken)
    {
        GetAllResult<MJadwalDokter> response = await repository.GetAll(
            page: request.Page,
            size: request.Size,
            search: request.Search,
            order: request.Order,
            orderAsc: request.OrderAsc
        );
        return new GetAllJadwalDokterResponse(response);
    }
}