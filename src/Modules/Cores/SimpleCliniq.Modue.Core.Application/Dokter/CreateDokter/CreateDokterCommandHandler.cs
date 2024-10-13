using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Dokter.CreateDokter;

internal sealed class CreateDokterCommandHandler(IDokterRepository repository)
    : ICommandHandler<CreateDokterCommand, CreateDokterResponse>
{
    public async Task<Result<CreateDokterResponse>> Handle(CreateDokterCommand request, CancellationToken cancellationToken)
    {
        MDokter model = await repository.Create(request.Data);
        return new CreateDokterResponse(model);
    }
}