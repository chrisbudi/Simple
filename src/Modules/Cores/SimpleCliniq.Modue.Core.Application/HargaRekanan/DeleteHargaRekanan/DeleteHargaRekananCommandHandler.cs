using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.HargaRekanan.DeleteHargaRekanan;

internal sealed class DeleteHargaRekananCommandHandler(IHargaRekananRepository repository)
    : ICommandHandler<DeleteHargaRekananCommand, DeleteHargaRekananResponse>
{
    public async Task<Result<DeleteHargaRekananResponse>> Handle(DeleteHargaRekananCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteHargaRekananResponse(request.Id);
    }
}