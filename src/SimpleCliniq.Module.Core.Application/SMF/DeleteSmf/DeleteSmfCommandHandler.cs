using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.SMF.DeleteSmf;

internal sealed class DeleteSmfCommandHandler(ISmfRepository repository)
    : ICommandHandler<DeleteSmfCommand, DeleteSmfResponse>
{
    public async Task<Result<DeleteSmfResponse>> Handle(DeleteSmfCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteSmfResponse(request.Id);
    }
}