using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Diagnosa.GetDiagnosa;

internal sealed class GetDiagnosaQueryHandler(IDiagnosaRepository repository)
    : IQueryHandler<GetDiagnosaQuery, GetDiagnosaResponse>
{
    public async Task<Result<GetDiagnosaResponse>> Handle(GetDiagnosaQuery request, CancellationToken cancellationToken)
    {
        MDiagnosa response = await repository.Get(request.Id);
        return new GetDiagnosaResponse(response);
    }
}