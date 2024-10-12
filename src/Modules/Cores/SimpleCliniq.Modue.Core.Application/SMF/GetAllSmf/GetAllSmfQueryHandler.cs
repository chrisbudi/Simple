using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.SMF.GetSmf;

internal sealed class GetAllSmfQueryHandler(ISmfRepository repository)
    : IQueryHandler<GetAllSmfQuery, GetAllSmfResponse>
{
    public async Task<Result<GetAllSmfResponse>> Handle(GetAllSmfQuery request, CancellationToken cancellationToken)
    {
        GetAllResult<MSmf> response = await repository.GetAll(
            page: request.Page,
            size: request.Size,
            search: request.Search,
            order: request.Order,
            orderAsc: request.OrderAsc
        );
        return new GetAllSmfResponse(response);
    }
}