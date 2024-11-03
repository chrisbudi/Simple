using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Rekanan.GetRekanan;

internal sealed class GetAllRekananQueryHandler(IRekananRepository repository)
    : IQueryHandler<GetAllRekananQuery, GetAllRekananResponse>
{
    public async Task<Result<GetAllRekananResponse>> Handle(GetAllRekananQuery request, CancellationToken cancellationToken)
    {
        GetAllResult<MRekanan> response = await repository.GetAll(
            page: request.Page,
            size: request.Size,
            search: request.Search,
            order: request.Order,
            orderAsc: request.OrderAsc
        );
        return new GetAllRekananResponse(response);
    }
}