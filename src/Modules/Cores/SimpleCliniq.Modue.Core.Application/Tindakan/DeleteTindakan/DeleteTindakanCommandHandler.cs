using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.Tindakan.DeleteTindakan;

internal sealed class DeleteTindakanCommandHandler(ITindakanRepository repository)
    : ICommandHandler<DeleteTindakanCommand, DeleteTindakanResponse>
{
    public async Task<Result<DeleteTindakanResponse>> Handle(DeleteTindakanCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteTindakanResponse(request.Id);
    }
}