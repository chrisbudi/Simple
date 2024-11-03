using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Tindakan.GetTindakan;

internal sealed class GetTindakanQueryHandler(ITindakanRepository repository)
    : IQueryHandler<GetTindakanQuery, GetTindakanResponse>
{
    public async Task<Result<GetTindakanResponse>> Handle(GetTindakanQuery request, CancellationToken cancellationToken)
    {
        MTindakan response = await repository.Get(request.Id);
        return new GetTindakanResponse(response);
    }
}