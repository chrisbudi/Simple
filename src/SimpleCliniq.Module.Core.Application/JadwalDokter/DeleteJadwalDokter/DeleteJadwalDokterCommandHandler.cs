using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.JadwalDokter.DeleteJadwalDokter;

internal sealed class DeleteJadwalDokterCommandHandler(IJadwalDokterRepository repository)
    : ICommandHandler<DeleteJadwalDokterCommand, DeleteJadwalDokterResponse>
{
    public async Task<Result<DeleteJadwalDokterResponse>> Handle(DeleteJadwalDokterCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteJadwalDokterResponse(request.Id);
    }
}