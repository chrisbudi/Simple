using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.RadiologiRekanan.GetRadiologiRekanan;

internal sealed class GetRadiologiRekananQueryHandler(IRadiologiRekananRepository repository)
    : IQueryHandler<GetRadiologiRekananQuery, GetRadiologiRekananResponse>
{
    public async Task<Result<GetRadiologiRekananResponse>> Handle(GetRadiologiRekananQuery request, CancellationToken cancellationToken)
    {
        MRadiologiRekanan response = await repository.Get(request.Id);
        return new GetRadiologiRekananResponse(response);
    }
}