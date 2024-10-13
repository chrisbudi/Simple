using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Ruang.GetRuang;

internal sealed class GetAllRuangQueryHandler(IRuangRepository repository)
    : IQueryHandler<GetAllRuangQuery, GetAllRuangResponse>
{
    public async Task<Result<GetAllRuangResponse>> Handle(GetAllRuangQuery request, CancellationToken cancellationToken)
    {
        GetAllResult<MRuang> response = await repository.GetAll(
            page: request.Page,
            size: request.Size,
            search: request.Search,
            order: request.Order,
            orderAsc: request.OrderAsc
        );
        return new GetAllRuangResponse(response);
    }
}