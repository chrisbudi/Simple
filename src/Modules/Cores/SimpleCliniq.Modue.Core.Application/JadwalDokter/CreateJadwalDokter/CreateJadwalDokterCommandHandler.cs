using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.JadwalDokter.CreateJadwalDokter;

internal sealed class CreateJadwalDokterCommandHandler(IJadwalDokterRepository repository)
    : ICommandHandler<CreateJadwalDokterCommand, CreateJadwalDokterResponse>
{
    public async Task<Result<CreateJadwalDokterResponse>> Handle(CreateJadwalDokterCommand request, CancellationToken cancellationToken)
    {
        MJadwalDokter model = await repository.Create(request.Data);
        return new CreateJadwalDokterResponse(model);
    }
}