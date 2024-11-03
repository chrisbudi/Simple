using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumRekanan.DeleteLaboratoriumRekanan;

internal sealed class DeleteLaboratoriumRekananCommandHandler(ILaboratoriumRekananRepository repository)
    : ICommandHandler<DeleteLaboratoriumRekananCommand, DeleteLaboratoriumRekananResponse>
{
    public async Task<Result<DeleteLaboratoriumRekananResponse>> Handle(DeleteLaboratoriumRekananCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteLaboratoriumRekananResponse(request.Id);
    }
}