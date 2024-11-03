using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.DiagnosaMatrix.CreateDiagnosaMatrix;

internal sealed class CreateDiagnosaMatrixCommandHandler(IDiagnosaMatrixRepository repository)
    : ICommandHandler<CreateDiagnosaMatrixCommand, CreateDiagnosaMatrixResponse>
{
    public async Task<Result<CreateDiagnosaMatrixResponse>> Handle(CreateDiagnosaMatrixCommand request, CancellationToken cancellationToken)
    {
        MDiagnosaMatrix model = await repository.Create(request.Data);
        return new CreateDiagnosaMatrixResponse(model);
    }
}