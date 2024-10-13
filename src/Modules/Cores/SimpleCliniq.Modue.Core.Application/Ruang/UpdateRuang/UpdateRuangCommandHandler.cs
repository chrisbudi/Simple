using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Ruang.UpdateRuang;

internal sealed class UpdateRuangCommandHandler(IRuangRepository repository)
    : ICommandHandler<UpdateRuangCommand, UpdateRuangResponse>
{
    public async Task<Result<UpdateRuangResponse>> Handle(UpdateRuangCommand request, CancellationToken cancellationToken)
    {
        MRuang model = await repository.Update(request.Data);
        return new UpdateRuangResponse(model);
    }
}