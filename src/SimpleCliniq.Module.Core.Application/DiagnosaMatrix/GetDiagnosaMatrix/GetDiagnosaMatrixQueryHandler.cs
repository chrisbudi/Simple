using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.DiagnosaMatrix.GetDiagnosaMatrix;

internal sealed class GetDiagnosaMatrixQueryHandler(IDiagnosaMatrixRepository repository)
    : IQueryHandler<GetDiagnosaMatrixQuery, GetDiagnosaMatrixResponse>
{
    public async Task<Result<GetDiagnosaMatrixResponse>> Handle(GetDiagnosaMatrixQuery request, CancellationToken cancellationToken)
    {
        MDiagnosaMatrix response = await repository.Get(request.Id);
        return new GetDiagnosaMatrixResponse(response);
    }
}