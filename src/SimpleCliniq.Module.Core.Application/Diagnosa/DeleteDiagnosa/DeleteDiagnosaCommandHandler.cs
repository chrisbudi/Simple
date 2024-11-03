using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.Diagnosa.DeleteDiagnosa;

internal sealed class DeleteDiagnosaCommandHandler(IDiagnosaRepository repository)
    : ICommandHandler<DeleteDiagnosaCommand, DeleteDiagnosaResponse>
{
    public async Task<Result<DeleteDiagnosaResponse>> Handle(DeleteDiagnosaCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteDiagnosaResponse(request.Id);
    }
}