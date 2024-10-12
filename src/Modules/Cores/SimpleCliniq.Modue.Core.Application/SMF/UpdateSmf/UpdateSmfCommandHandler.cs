using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.SMF.UpdateSmf;

internal sealed class UpdateSmfCommandHandler(ISmfRepository repository)
    : ICommandHandler<UpdateSmfCommand, UpdateSmfResponse>
{
    public async Task<Result<UpdateSmfResponse>> Handle(UpdateSmfCommand request, CancellationToken cancellationToken)
    {
        MSmf model = await repository.Update(request.Data);
        return new UpdateSmfResponse(model);
    }
}