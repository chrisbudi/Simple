using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.RadiologiHarga.UpdateRadiologiHarga;

internal sealed class UpdateRadiologiHargaCommandHandler(IRadiologiHargaRepository repository)
    : ICommandHandler<UpdateRadiologiHargaCommand, UpdateRadiologiHargaResponse>
{
    public async Task<Result<UpdateRadiologiHargaResponse>> Handle(UpdateRadiologiHargaCommand request, CancellationToken cancellationToken)
    {
        MRadiologiHarga model = await repository.Update(request.Data);
        return new UpdateRadiologiHargaResponse(model);
    }
}