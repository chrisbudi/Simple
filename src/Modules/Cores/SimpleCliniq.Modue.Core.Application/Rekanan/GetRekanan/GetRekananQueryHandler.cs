using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Rekanan.GetRekanan;

internal sealed class GetRekananQueryHandler(IRekananRepository repository)
    : IQueryHandler<GetRekananQuery, GetRekananResponse>
{
    public async Task<Result<GetRekananResponse>> Handle(GetRekananQuery request, CancellationToken cancellationToken)
    {
        MRekanan response = await repository.Get(request.Id);
        return new GetRekananResponse(response);
    }
}