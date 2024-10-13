using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Pasien.UpdatePasien;

internal sealed class UpdatePasienCommandHandler(IPasienRepository repository)
    : ICommandHandler<UpdatePasienCommand, UpdatePasienResponse>
{
    public async Task<Result<UpdatePasienResponse>> Handle(UpdatePasienCommand request, CancellationToken cancellationToken)
    {
        MPasien model = await repository.Update(request.Data);
        return new UpdatePasienResponse(model);
    }
}