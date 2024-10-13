using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Diagnosa.UpdateDiagnosa;

internal sealed class UpdateDiagnosaCommandHandler(IDiagnosaRepository repository)
    : ICommandHandler<UpdateDiagnosaCommand, UpdateDiagnosaResponse>
{
    public async Task<Result<UpdateDiagnosaResponse>> Handle(UpdateDiagnosaCommand request, CancellationToken cancellationToken)
    {
        MDiagnosa model = await repository.Update(request.Data);
        return new UpdateDiagnosaResponse(model);
    }
}