using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.DiagnosaMatrix.GetDiagnosaMatrix;

internal sealed class GetAllDiagnosaMatrixQueryHandler(IDiagnosaMatrixRepository diagnosaMatrixRepository)
    : IQueryHandler<GetAllDiagnosaMatrixQuery, GetAllDiagnosaMatrixResponse>
{
    public async Task<Result<GetAllDiagnosaMatrixResponse>> Handle(GetAllDiagnosaMatrixQuery request, CancellationToken cancellationToken)
    {
        GetAllResult<MDiagnosaMatrix> response = await diagnosaMatrixRepository.GetAll(
            page: request.Page,
            size: request.Size,
            searchIdRuangan: request.SearchIdRuangan,
            order: request.Order,
            orderAsc: request.OrderAsc
        );
        return new GetAllDiagnosaMatrixResponse(response);
    }
}