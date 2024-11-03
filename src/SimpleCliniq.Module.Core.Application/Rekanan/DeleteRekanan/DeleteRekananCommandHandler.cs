using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.Rekanan.DeleteRekanan;

internal sealed class DeleteRekananCommandHandler(IRekananRepository repository)
    : ICommandHandler<DeleteRekananCommand, DeleteRekananResponse>
{
    public async Task<Result<DeleteRekananResponse>> Handle(DeleteRekananCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteRekananResponse(request.Id);
    }
}