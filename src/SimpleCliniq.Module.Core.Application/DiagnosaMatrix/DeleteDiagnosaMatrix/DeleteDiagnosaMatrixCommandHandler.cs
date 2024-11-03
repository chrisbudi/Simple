using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.DiagnosaMatrix.DeleteDiagnosaMatrix;

internal sealed class DeleteDiagnosaMatrixCommandHandler(IDiagnosaMatrixRepository repository)
    : ICommandHandler<DeleteDiagnosaMatrixCommand, DeleteDiagnosaMatrixResponse>
{
    public async Task<Result<DeleteDiagnosaMatrixResponse>> Handle(DeleteDiagnosaMatrixCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteDiagnosaMatrixResponse(request.Id);
    }
}