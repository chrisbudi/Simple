using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Dokter.GetDokter;

internal sealed class GetAllDokterQueryHandler(IDokterRepository repository)
    : IQueryHandler<GetAllDokterQuery, GetAllDokterResponse>
{
    public async Task<Result<GetAllDokterResponse>> Handle(GetAllDokterQuery request, CancellationToken cancellationToken)
    {
        GetAllResult<MDokter> response = await repository.GetAll(
            page: request.Page,
            size: request.Size,
            search: request.Search,
            order: request.Order,
            orderAsc: request.OrderAsc
        );
        return new GetAllDokterResponse(response);
    }
}