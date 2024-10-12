using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.Dokter.DeleteDokter;

internal sealed class DeleteDokterCommandHandler(IDokterRepository repository)
    : ICommandHandler<DeleteDokterCommand, DeleteDokterResponse>
{
    public async Task<Result<DeleteDokterResponse>> Handle(DeleteDokterCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteDokterResponse(request.Id);
    }
}