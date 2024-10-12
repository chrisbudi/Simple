using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumHarga.UpdateLaboratoriumHarga;

internal sealed class UpdateLaboratoriumHargaCommandHandler(ILaboratoriumHargaRepository repository)
    : ICommandHandler<UpdateLaboratoriumHargaCommand, UpdateLaboratoriumHargaResponse>
{
    public async Task<Result<UpdateLaboratoriumHargaResponse>> Handle(UpdateLaboratoriumHargaCommand request, CancellationToken cancellationToken)
    {
        MLaboratoriumHarga model = await repository.Update(request.Data);
        return new UpdateLaboratoriumHargaResponse(model);
    }
}