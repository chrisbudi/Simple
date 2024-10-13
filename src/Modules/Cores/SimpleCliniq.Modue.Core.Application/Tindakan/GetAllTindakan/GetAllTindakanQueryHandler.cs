using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Tindakan.GetTindakan;

internal sealed class GetAllTindakanQueryHandler(ITindakanRepository repository)
    : IQueryHandler<GetAllTindakanQuery, GetAllTindakanResponse>
{
    public async Task<Result<GetAllTindakanResponse>> Handle(GetAllTindakanQuery request, CancellationToken cancellationToken)
    {
        GetAllResult<MTindakan> response = await repository.GetAll(
            page: request.Page,
            size: request.Size,
            search: request.Search,
            order: request.Order,
            orderAsc: request.OrderAsc
        );
        return new GetAllTindakanResponse(response);
    }
}