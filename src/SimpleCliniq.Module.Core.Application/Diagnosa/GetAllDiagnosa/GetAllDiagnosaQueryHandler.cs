using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Diagnosa.GetDiagnosa;

internal sealed class GetAllDiagnosaQueryHandler(IDiagnosaRepository repository)
    : IQueryHandler<GetAllDiagnosaQuery, GetAllDiagnosaResponse>
{
    public async Task<Result<GetAllDiagnosaResponse>> Handle(GetAllDiagnosaQuery request, CancellationToken cancellationToken)
    {
        GetAllResult<MDiagnosa> response = await repository.GetAll(
            page: request.Page,
            size: request.Size,
            search: request.Search,
            order: request.Order,
            orderAsc: request.OrderAsc
        );
        return new GetAllDiagnosaResponse(response);
    }
}