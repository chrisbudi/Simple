using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.HargaRekanan.GetHargaRekanan;

internal sealed class GetHargaRekananQueryHandler(IHargaRekananRepository repository)
    : IQueryHandler<GetHargaRekananQuery, GetHargaRekananResponse>
{
    public async Task<Result<GetHargaRekananResponse>> Handle(GetHargaRekananQuery request, CancellationToken cancellationToken)
    {
        MHargaRekanan response = await repository.Get(request.Id);
        return new GetHargaRekananResponse(response);
    }
}