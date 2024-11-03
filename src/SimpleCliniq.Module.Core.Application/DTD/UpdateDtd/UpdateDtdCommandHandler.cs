using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Application.DTD.UpdateDtd;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.DTD.UpdateDtd;

internal sealed class UpdateDtdCommandHandler(IDtdRepository repository)
    : ICommandHandler<UpdateDtdCommand, UpdateDtdResponse>
{
    public async Task<Result<UpdateDtdResponse>> Handle(UpdateDtdCommand request, CancellationToken cancellationToken)
    {
        MDtd model = await repository.Update(request.Data);
        return new UpdateDtdResponse(model);
    }
}