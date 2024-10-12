using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Tindakan.CreateTindakan;

internal sealed class CreateTindakanCommandHandler(ITindakanRepository repository)
    : ICommandHandler<CreateTindakanCommand, CreateTindakanResponse>
{
    public async Task<Result<CreateTindakanResponse>> Handle(CreateTindakanCommand request, CancellationToken cancellationToken)
    {
        MTindakan model = await repository.Create(request.Data);
        return new CreateTindakanResponse(model);
    }
}