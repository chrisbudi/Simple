using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.SMF.CreateSmf;

internal sealed class CreateSmfCommandHandler(ISmfRepository repository)
    : ICommandHandler<CreateSmfCommand, CreateSmfResponse>
{
    public async Task<Result<CreateSmfResponse>> Handle(CreateSmfCommand request, CancellationToken cancellationToken)
    {
        MSmf model = await repository.Create(request.Data);
        return new CreateSmfResponse(model);
    }
}