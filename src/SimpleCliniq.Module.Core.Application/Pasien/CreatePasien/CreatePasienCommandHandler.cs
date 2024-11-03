using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Pasien.CreatePasien;

internal sealed class CreatePasienCommandHandler(IPasienRepository repository)
    : ICommandHandler<CreatePasienCommand, CreatePasienResponse>
{
    public async Task<Result<CreatePasienResponse>> Handle(CreatePasienCommand request, CancellationToken cancellationToken)
    {
        MPasien model = await repository.Create(request.Data);
        return new CreatePasienResponse(model);
    }
}