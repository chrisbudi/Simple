using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Diagnosa.CreateDiagnosa;

internal sealed class CreateDiagnosaCommandHandler(IDiagnosaRepository repository)
    : ICommandHandler<CreateDiagnosaCommand, CreateDiagnosaResponse>
{
    public async Task<Result<CreateDiagnosaResponse>> Handle(CreateDiagnosaCommand request, CancellationToken cancellationToken)
    {
        MDiagnosa model = await repository.Create(request.Data);
        return new CreateDiagnosaResponse(model);
    }
}