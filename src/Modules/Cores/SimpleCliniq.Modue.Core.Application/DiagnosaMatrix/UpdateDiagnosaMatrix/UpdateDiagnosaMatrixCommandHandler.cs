using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.DiagnosaMatrix.UpdateDiagnosaMatrix;

internal sealed class UpdateDiagnosaMatrixCommandHandler(IDiagnosaMatrixRepository repository)
    : ICommandHandler<UpdateDiagnosaMatrixCommand, UpdateDiagnosaMatrixResponse>
{
    public async Task<Result<UpdateDiagnosaMatrixResponse>> Handle(UpdateDiagnosaMatrixCommand request, CancellationToken cancellationToken)
    {
        MDiagnosaMatrix model = await repository.Update(request.Data);
        return new UpdateDiagnosaMatrixResponse(model);
    }
}