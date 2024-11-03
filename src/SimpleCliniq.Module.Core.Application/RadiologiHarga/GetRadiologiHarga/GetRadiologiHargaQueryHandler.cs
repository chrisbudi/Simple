using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.RadiologiHarga.GetRadiologiHarga;

internal sealed class GetRadiologiHargaQueryHandler(IRadiologiHargaRepository repository)
    : IQueryHandler<GetRadiologiHargaQuery, GetRadiologiHargaResponse>
{
    public async Task<Result<GetRadiologiHargaResponse>> Handle(GetRadiologiHargaQuery request, CancellationToken cancellationToken)
    {
        MRadiologiHarga response = await repository.Get(request.Id);
        return new GetRadiologiHargaResponse(response);
    }
}