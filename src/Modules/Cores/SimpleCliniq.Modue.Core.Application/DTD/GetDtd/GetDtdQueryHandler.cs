using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.DTD.GetDtd;

internal sealed class GetDtdQueryHandler(IDtdRepository repository)
    : IQueryHandler<GetDtdQuery, GetDtdResponse>
{
    public async Task<Result<GetDtdResponse>> Handle(GetDtdQuery request, CancellationToken cancellationToken)
    {
        MDtd response = await repository.Get(request.Id);
        return new GetDtdResponse(response);
    }
}