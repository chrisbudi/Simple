using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumHarga.DeleteLaboratoriumHarga;

internal sealed class DeleteLaboratoriumHargaCommandHandler(ILaboratoriumHargaRepository repository)
    : ICommandHandler<DeleteLaboratoriumHargaCommand, DeleteLaboratoriumHargaResponse>
{
    public async Task<Result<DeleteLaboratoriumHargaResponse>> Handle(DeleteLaboratoriumHargaCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteLaboratoriumHargaResponse(request.Id);
    }
}