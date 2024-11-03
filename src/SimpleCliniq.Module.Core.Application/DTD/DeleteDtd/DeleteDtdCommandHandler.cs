using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.DTD.DeleteDtd;

internal sealed class DeleteDtdCommandHandler(IDtdRepository repository)
    : ICommandHandler<DeleteDtdCommand, DeleteDtdResponse>
{
    public async Task<Result<DeleteDtdResponse>> Handle(DeleteDtdCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteDtdResponse(request.Id);
    }
}