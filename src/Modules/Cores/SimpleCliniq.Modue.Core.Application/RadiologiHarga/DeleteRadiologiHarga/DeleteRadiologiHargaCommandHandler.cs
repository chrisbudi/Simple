using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.RadiologiHarga.DeleteRadiologiHarga;

internal sealed class DeleteRadiologiHargaCommandHandler(IRadiologiHargaRepository repository)
    : ICommandHandler<DeleteRadiologiHargaCommand, DeleteRadiologiHargaResponse>
{
    public async Task<Result<DeleteRadiologiHargaResponse>> Handle(DeleteRadiologiHargaCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteRadiologiHargaResponse(request.Id);
    }
}