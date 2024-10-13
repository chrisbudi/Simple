using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.Pasien.DeletePasien;

internal sealed class DeletePasienCommandHandler(IPasienRepository repository)
    : ICommandHandler<DeletePasienCommand, DeletePasienResponse>
{
    public async Task<Result<DeletePasienResponse>> Handle(DeletePasienCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeletePasienResponse(request.Id);
    }
}