using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.JadwalDokter.UpdateJadwalDokter;

internal sealed class UpdateJadwalDokterCommandHandler(IJadwalDokterRepository repository)
    : ICommandHandler<UpdateJadwalDokterCommand, UpdateJadwalDokterResponse>
{
    public async Task<Result<UpdateJadwalDokterResponse>> Handle(UpdateJadwalDokterCommand request, CancellationToken cancellationToken)
    {
        MJadwalDokter model = await repository.Update(request.Data);
        return new UpdateJadwalDokterResponse(model);
    }
}