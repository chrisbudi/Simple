using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Dokter.UpdateDokter;

internal sealed class UpdateDokterCommandHandler(IDokterRepository repository)
    : ICommandHandler<UpdateDokterCommand, UpdateDokterResponse>
{
    public async Task<Result<UpdateDokterResponse>> Handle(UpdateDokterCommand request, CancellationToken cancellationToken)
    {
        MDokter model = await repository.Update(request.Data);
        return new UpdateDokterResponse(model);
    }
}