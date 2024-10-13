using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.DTD.GetDtd;

internal sealed class GetAllDtdQueryHandler(IDtdRepository repository)
    : IQueryHandler<GetAllDtdQuery, GetAllDtdResponse>
{
    public async Task<Result<GetAllDtdResponse>> Handle(GetAllDtdQuery request, CancellationToken cancellationToken)
    {
        GetAllResult<MDtd> response = await repository.GetAll(
            page: request.Page,
            size: request.Size,
            search: request.Search,
            order: request.Order,
            orderAsc: request.OrderAsc
        );
        return new GetAllDtdResponse(response);
    }
}