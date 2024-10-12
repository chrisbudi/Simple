using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumHarga.GetLaboratoriumHarga;

internal sealed class GetLaboratoriumHargaQueryHandler(ILaboratoriumHargaRepository repository)
    : IQueryHandler<GetLaboratoriumHargaQuery, GetLaboratoriumHargaResponse>
{
    public async Task<Result<GetLaboratoriumHargaResponse>> Handle(GetLaboratoriumHargaQuery request, CancellationToken cancellationToken)
    {
        MLaboratoriumHarga response = await repository.Get(request.Id);
        return new GetLaboratoriumHargaResponse(response);
    }
}