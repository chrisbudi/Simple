using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.RadiologiRekanan.DeleteRadiologiRekanan;

internal sealed class DeleteRadiologiRekananCommandHandler(IRadiologiRekananRepository repository)
    : ICommandHandler<DeleteRadiologiRekananCommand, DeleteRadiologiRekananResponse>
{
    public async Task<Result<DeleteRadiologiRekananResponse>> Handle(DeleteRadiologiRekananCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteRadiologiRekananResponse(request.Id);
    }
}