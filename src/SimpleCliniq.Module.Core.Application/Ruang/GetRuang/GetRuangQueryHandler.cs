using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Ruang.GetRuang;

internal sealed class GetRuangQueryHandler(IRuangRepository repository)
    : IQueryHandler<GetRuangQuery, GetRuangResponse>
{
    public async Task<Result<GetRuangResponse>> Handle(GetRuangQuery request, CancellationToken cancellationToken)
    {
        MRuang response = await repository.Get(request.Id);
        return new GetRuangResponse(response);
    }
}