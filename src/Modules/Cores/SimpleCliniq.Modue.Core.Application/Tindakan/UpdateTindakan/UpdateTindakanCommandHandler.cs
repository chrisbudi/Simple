using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Tindakan.UpdateTindakan;

internal sealed class UpdateTindakanCommandHandler(ITindakanRepository repository)
    : ICommandHandler<UpdateTindakanCommand, UpdateTindakanResponse>
{
    public async Task<Result<UpdateTindakanResponse>> Handle(UpdateTindakanCommand request, CancellationToken cancellationToken)
    {
        MTindakan model = await repository.Update(request.Data);
        return new UpdateTindakanResponse(model);
    }
}