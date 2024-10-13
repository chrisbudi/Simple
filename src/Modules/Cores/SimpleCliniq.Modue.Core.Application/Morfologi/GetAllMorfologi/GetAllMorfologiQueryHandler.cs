using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Morfologi.GetMorfologi;

internal sealed class GetAllMorfologiQueryHandler(IMorfologiRepository repository)
    : IQueryHandler<GetAllMorfologiQuery, GetAllMorfologiResponse>
{
    public async Task<Result<GetAllMorfologiResponse>> Handle(GetAllMorfologiQuery request, CancellationToken cancellationToken)
    {
        GetAllResult<MMorfologi> response = await repository.GetAll(
            page: request.Page,
            size: request.Size,
            search: request.Search,
            order: request.Order,
            orderAsc: request.OrderAsc
        );
        return new GetAllMorfologiResponse(response);
    }
}