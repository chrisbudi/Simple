using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Pasien.GetPasien;

internal sealed class GetAllPasienQueryHandler(IPasienRepository repository)
    : IQueryHandler<GetAllPasienQuery, GetAllPasienResponse>
{
    public async Task<Result<GetAllPasienResponse>> Handle(GetAllPasienQuery request, CancellationToken cancellationToken)
    {
        GetAllResult<MPasien> response = await repository.GetAll(
            page: request.Page,
            size: request.Size,
            search: request.Search,
            order: request.Order,
            orderAsc: request.OrderAsc
        );
        return new GetAllPasienResponse(response);
    }
}